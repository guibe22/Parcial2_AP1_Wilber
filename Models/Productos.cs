using System.ComponentModel.DataAnnotations;

public class Productos
{
    [Key]
    public int ProductoId { get; set; }
    [Required(ErrorMessage ="la Descripcion es requerida.")]
    public String? Descripcion { get; set; }
    [Required(ErrorMessage ="el Costo es requerido.")]
    public Double Costo { get; set; }
    [Required(ErrorMessage ="el Precio es requerido.")]
    public Double Precio { get; set; }
    [Required(ErrorMessage ="la Existencia es requerida.")]
    public int Existencia { get; set; }
}