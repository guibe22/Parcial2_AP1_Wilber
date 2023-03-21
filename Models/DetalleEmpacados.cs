using System.ComponentModel.DataAnnotations;

public class DetalleEmpacados
{
    [Key]
    public int DetalleEmpacadosId { get; set; }
    public int EmpacadosId { get; set; }
    public int ProductoId { get; set; }
    [Required(ErrorMessage ="La Cantidad es requerida.")]
    [Range(1, double.MaxValue, ErrorMessage = "La Cantidad debe ser mayor que cero.")]
    public int Cantidad { get; set; }
}