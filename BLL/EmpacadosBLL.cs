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

         _Contexto.Empacados.Add(empacado);
         return _Contexto.SaveChanges() >0;
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
        }

         foreach (var detalle in empacado.detalleEmpacados)
        {
            var producto = _Contexto.Productos.Find(detalle.ProductoId);
            if(producto!=null){
                producto.Existencia-= detalle.Cantidad;
                _Contexto.Entry(producto).State = EntityState.Modified;
               _Contexto.Set<DetalleEmpacados>().Add(detalle);
            }
        }

        var DetalleEliminar = _Contexto.Set<DetalleEmpacados>().Where(o => o.EmpacadosId == empacado.EmpacadoId);
         _Contexto.Set<DetalleEmpacados>().RemoveRange(DetalleEliminar);
         _Contexto.Entry(empacado).State = EntityState.Deleted;
         _Contexto.SaveChanges();
         _Contexto.Empacados.Add(empacado);
         return  _Contexto.SaveChanges() >0;
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
        var DetalleEliminar = _Contexto.Set<DetalleEmpacados>().Where(o => o.EmpacadosId == empacado.EmpacadoId);
         _Contexto.Set<DetalleEmpacados>().RemoveRange(DetalleEliminar);
         _Contexto.Entry(empacado).State = EntityState.Deleted;
         return _Contexto.SaveChanges() >0;
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