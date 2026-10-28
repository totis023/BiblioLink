using System.ComponentModel.DataAnnotations;
namespace BiblioLink.DTOs;

public class UsuarioCreateDTO
{
    [Required(ErrorMessage = "La matrícula es obligatoria.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "La matrícula debe tener entre 3 y 50 caracteres.")]
    public string Matricula { get; set; } = string.Empty;

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 100 caracteres.")]
    public string Apellido { get; set; } = string.Empty;

    [Required(ErrorMessage = "El tipo de usuario es obligatorio.")]
    [StringLength(50)]
    public string Tipo { get; set; } = string.Empty; // Ejemplo: "Alumno" o "Personal"

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
    [StringLength(150)]
    public string Email { get; set; } = string.Empty;
}

public class UsuarioUpdateDTO : UsuarioCreateDTO { }

public class UsuarioReadDTO
{
    public int Id { get; set; }
    public string Matricula { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}