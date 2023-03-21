using System.ComponentModel.DataAnnotations;

public class DetalleEmpacados
{
    [Key]
    public int DetalleEmpacadosId { get; set; }
    [Required(ErrorMessage ="el EmpacadoId es requerido.")]
    public int EmpacadosId { get; set; }
    [Required(ErrorMessage ="el ProductoId es requerido.")]
    public int ProductoId { get; set; }
    [Required(ErrorMessage ="La Descripcion es requerida.")]
    public String? Descripcion {get;set;}
    [Required(ErrorMessage ="La Cantidad es requerida.")]
    [Range(1, double.MaxValue, ErrorMessage = "La Cantidad debe ser mayor que cero.")]
    public int Cantidad { get; set; }
}