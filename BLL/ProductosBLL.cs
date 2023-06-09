using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class ProductosBLL
{
    private readonly Contexto _Contexto;

    public ProductosBLL(Contexto Contexto)
    {
        _Contexto= Contexto;
    }
    public bool Existe(int ProductoId){
         return _Contexto.Productos.Any(o=> o.ProductoId==ProductoId);
    }
    
    private bool Insertar (Productos producto){
         _Contexto.Productos.Add(producto);
         return _Contexto.SaveChanges() >0;
    }
    private bool Modificar (Productos producto){
         _Contexto.Entry(producto).State = EntityState.Modified;
         return  _Contexto.SaveChanges() >0;
    }
    public bool Guardar(Productos producto){
         if(!Existe(producto.ProductoId) ){
             return this.Insertar(producto);
         }
         else{
             return this.Modificar(producto);
         }
    }

     public bool Eliminar (Productos producto){
         _Contexto.Entry(producto).State = EntityState.Deleted;
         return _Contexto.SaveChanges() >0;
    }
    public Productos? Buscar(String Nombre){
         return _Contexto.Productos.Where(o => o.Descripcion== Nombre).AsTracking().SingleOrDefault();
    }

     public Productos? Buscar(int id){
         return _Contexto.Productos.Where(o => o.ProductoId== id).AsTracking().SingleOrDefault();
    }

    public List<Productos> GetList(Expression<Func<Productos,bool>>criterio){
         return _Contexto.Productos.AsNoTracking().Where(criterio).ToList();
    }
}