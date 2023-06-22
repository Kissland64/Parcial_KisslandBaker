using System.ComponentModel.DataAnnotations;

public class Gasto
{

    [Key]
    public int GastoId { get; set; }
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Este campo es necesario")]
    public string Categoria { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este campo es necesario")]
    [Range(1, 1000, ErrorMessage = "El monto tiene que ser entre {1} y {2}")]
    public float Monto { get; set; }

    [Required(ErrorMessage = "Este campo es necesario")]
    [Range(1, 900, ErrorMessage = "El balance tiene que ser entre {1} y {2}")]
    public float Balance { get; set; }

}