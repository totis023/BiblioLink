namespace BiblioLink.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Matricula { get; set; } = string.Empty; // string.Empty para evitar warnings de nulabilidad
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

}