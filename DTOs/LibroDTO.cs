using System.ComponentModel.DataAnnotations;

namespace BiblioLink.DTOs;

public class LibroCreateDTO
{
    [Required(ErrorMessage = "El título es obligatorio.")]
    [StringLength(200, MinimumLength = 1)]
    public string Titulo {get; set;} = string.Empty;

    [Required(ErrorMessage = "El autor es obligatorio.")]
    [StringLength(300)]
    public string Autores {get; set;} = string.Empty;

    [Required(ErrorMessage = "El ISBN es obligatorio.")]
    [StringLength(20, MinimumLength = 10)]
    public string ISBN {get; set;} = string.Empty;

    [Required(ErrorMessage = "La editorial es obligatoria.")]
    [StringLength(150)]
    public string Editorial {get; set;} = string.Empty;

    [Range(1450, 2100, ErrorMessage = "El año de publicación no es válido.")]
    public int AnioPublicacion {get; set;}

    [Required(ErrorMessage = "La ubicación es obligatoria.")]
    [StringLength(100)]
    public string UbicacionFisica {get; set;} = string.Empty;

    [Range(1, 10000, ErrorMessage = "La cantidad total debe ser al menos 1.")]
    public int CantidadTotal {get; set;}
}

public class LibroUpdateDTO : LibroCreateDTO { }

public class LibroReadDTO
{
    public int Id {get; set;}
    public string Titulo {get; set;} = string.Empty;
    public string Autores {get; set;} = string.Empty;
    public string ISBN {get; set;} = string.Empty;
    public string Editorial {get; set;} = string.Empty;
    public int AnioPublicacion {get; set;}
    public string UbicacionFisica {get; set;} = string.Empty;
    public int CantidadTotal {get; set;}
    public int CantidadDisponible {get; set;}
}