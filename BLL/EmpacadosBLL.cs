using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class EmpacadosBLL
{
    private readonly Contexto _Contexto;

    public EmpacadosBLL(Contexto Contexto)
    {
        _Contexto= Contexto;
    }

    public bool Existe(int EmpacadoId ){
         return _Contexto.Empacados.Any(o=> o.EmpacadoId==EmpacadoId);
    }

    private bool Insertar (Empacados empacado){
        foreach (var detalle in empacado.detalleEmpacados)
        {
            var producto = _Contexto.Productos.Find(detalle.ProductoId);
            if(producto!=null){
                producto.Existencia-= detalle.Cantidad;
                _Contexto.Entry(producto).State = EntityState.Modified;
            }
        }
        var producido = _Contexto.Productos.Find(empacado.Producido);
        if(producido!=null){
            producido.Existencia+= empacado.CantidadProducida;
             _Contexto.Entry(producido).State = EntityState.Modified;
        }

         _Contexto.Empacados.Add(empacado);
        bool save = _Contexto.SaveChanges() >0;
        _Contexto.Entry(empacado).State = EntityState.Detached;
         return  save;
    }

    private bool Modificar (Empacados empacado){
        var empacadoAnterior = _Contexto.Empacados
             .Where(o => o.EmpacadoId== empacado.EmpacadoId)
             .Include(o =>  o.detalleEmpacados)
             .AsNoTracking()
             .SingleOrDefault();
        if(empacadoAnterior!=null){
            foreach (var detalle in empacadoAnterior.detalleEmpacados)
            {
                var producto = _Contexto.Productos.Find(detalle.ProductoId);
                if(producto!=null){
                    producto.Existencia += detalle.Cantidad;
                    _Contexto.Entry(producto).State = EntityState.Modified;
                }
            }
            var producidoAnterior = _Contexto.Productos.Find(empacadoAnterior.Producido);
            if(producidoAnterior!=null){
                producidoAnterior.Existencia-= empacadoAnterior.CantidadProducida;
                _Contexto.Entry(producidoAnterior).State = EntityState.Modified;
            }
            _Contexto.Entry(empacadoAnterior).State = EntityState.Detached;
        }
       
        
        
      

         foreach (var detalle in empacado.detalleEmpacados)
        {
            var producto = _Contexto.Productos.Find(detalle.ProductoId);
            if(producto!=null){
                producto.Existencia-= detalle.Cantidad;
                _Contexto.Entry(producto).State = EntityState.Modified;
                
            }
        }

         var producido= _Contexto.Productos.Find(empacado.Producido);
        if(producido!=null){
            producido.Existencia+= empacado.CantidadProducida;
             _Contexto.Entry(producido).State = EntityState.Modified;
        }
      

         var DetalleEliminar = _Contexto.Set<DetalleEmpacados>().Where(o => o.EmpacadosId == empacado.EmpacadoId);
         _Contexto.Set<DetalleEmpacados>().RemoveRange(DetalleEliminar);
         _Contexto.Set<DetalleEmpacados>().AddRange(empacado.detalleEmpacados);

         _Contexto.Entry(empacado).State = EntityState.Modified;
         bool save = _Contexto.SaveChanges() >0;
        _Contexto.Entry(empacado).State = EntityState.Detached;
         return  save; 
          
    }

    public bool Guardar( Empacados empacado){
         if(!Existe(empacado.EmpacadoId)){
             return this.Insertar(empacado);
         }
         else{
             return this.Modificar(empacado);
         }
    }

     public bool Eliminar (Empacados empacado){
         foreach (var detalle in empacado.detalleEmpacados)
        {
            var producto = _Contexto.Productos.Find(detalle.ProductoId);
            if(producto!=null){
                producto.Existencia+= detalle.Cantidad;
                _Contexto.Entry(producto).State = EntityState.Modified;
           
            }
        }
          var producido = _Contexto.Productos.Find(empacado.Producido);
        if(producido!=null){
            producido.Existencia-= empacado.CantidadProducida;
             _Contexto.Entry(producido).State = EntityState.Modified;
        }

        var DetalleEliminar = _Contexto.Set<DetalleEmpacados>().Where(o => o.EmpacadosId == empacado.EmpacadoId);
         _Contexto.Set<DetalleEmpacados>().RemoveRange(DetalleEliminar);
         _Contexto.Entry(empacado).State = EntityState.Deleted;
          bool save = _Contexto.SaveChanges() >0;
        _Contexto.Entry(empacado).State = EntityState.Detached;
         return  save; 
    }

    public Empacados? Buscar(int EmpacadoId){
         return _Contexto.Empacados
             .Where(o => o.EmpacadoId== EmpacadoId)
             .Include(o =>  o.detalleEmpacados)
             .AsNoTracking()
             .SingleOrDefault();
             
    }

    public List<Empacados> GetList(Expression<Func<Empacados,bool>>criterio){
         return _Contexto.Empacados.AsNoTracking().Where(criterio).ToList();
    }
}