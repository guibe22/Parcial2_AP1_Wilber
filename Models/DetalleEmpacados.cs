using System.ComponentModel.DataAnnotations;

public class DetalleEmpacados
{
    [Key]
    public int DetalleEmpacadosId { get; set; }
    public int EmpacadosId { get; set; }
    public int Cantidad { get; set; }
}