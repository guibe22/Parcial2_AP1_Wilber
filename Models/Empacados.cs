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
    public int Producido { get; set; }
    [Required(ErrorMessage ="la Cantidad es Requerida.")]
    public int CantidadUtilizada { get; set; }
    public int CantidadProducida { get; set; }
    [ForeignKey("EmpacadosId")]
    public List<DetalleEmpacados> detalleEmpacados { get; set; } = new List<DetalleEmpacados>();
}