using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Empacados
{
    [Key]
    public int EmpacadoId { get; set; }
    [Required(ErrorMessage ="la Fecha es requerida.")]
    public DateOnly Fecha { get; set; }
    [Required(ErrorMessage ="El Concepto es requerido.")]
    public String? Concepto { get; set; }
    [Required(ErrorMessage =" El Nombre del nuevo Producto es Requerido.")]
    public String? Producido { get; set; }
    [Required(ErrorMessage ="la Cantidad es Requerida.")]
    public int Cantidad { get; set; }
    [ForeignKey("EmpacadosId")]
    public List<DetalleEmpacados> detalleEmpacados { get; set; } = new List<DetalleEmpacados>();
}