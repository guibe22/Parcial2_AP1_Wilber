using Microsoft.EntityFrameworkCore;

public class Contexto :DbContext
{
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Empacados> Empacados {get; set;}

    public Contexto(DbContextOptions<Contexto> options) :base(options)
    {
        
    }

     protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Productos>().HasData(
                new Productos
                {
                    ProductoId= 1,
                    Descripcion= "Mani",
                    Costo=10,
                    Precio= 25,
                    Categoria="Normal",
                    Existencia= 100
                },
                new Productos
                {
                    ProductoId= 2,
                    Descripcion= "Pistachos",
                    Costo=50,
                    Precio= 120,
                    Categoria="Normal",
                    Existencia= 100
                },
                new Productos
                {
                    ProductoId= 3,
                    Descripcion= "Pasas",
                    Costo=25,
                    Precio= 50,
                    Categoria="Normal",
                    Existencia= 100
                },
                 new Productos
                {
                    ProductoId= 4,
                    Descripcion= "Ciruelas",
                    Costo=25,
                    Precio= 50,
                    Categoria="Normal",
                    Existencia= 100
                },
                new Productos{

                    ProductoId= 5,
                    Descripcion= "Mixto",
                    Costo=100,
                    Precio= 150,
                    Categoria="Empacado",
                    Existencia= 0
                }
        );
     }
}