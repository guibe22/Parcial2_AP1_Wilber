using System.ComponentModel.DataAnnotations;

public class Productos
{
    [Key]
    public int ProductoId { get; set; }
    [Required(ErrorMessage ="la Descripcion es requerida.")]
    public String? Descripcion { get; set; }
    [Required(ErrorMessage ="el Costo es requerido.")]
    [Range(1, double.MaxValue, ErrorMessage = "El costo debe ser mayor que cero.")]
    public Double Costo { get; set; }
    [Required(ErrorMessage ="el Precio es requerido.")]
    [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
    public Double Precio { get; set; }
    [Required(ErrorMessage ="la Categoria es requerida.")]
    public String? Categoria { get; set; }
    [Required(ErrorMessage ="la Existencia es requerida.")]
    public int Existencia { get; set; }
}