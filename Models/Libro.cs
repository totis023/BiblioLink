namespace BiblioLink.Models;

public class Libro
{
    public int Id {get; set;}
    public string Titulo {get; set;} = string.Empty; //string.Empty para que no genere warning el nullable
    public string Autores {get; set;} = string.Empty;
    public string ISBN {get; set;} = string.Empty;
    public string Editorial {get; set;} = string.Empty;
    public int AnioPublicacion {get; set;}
    public string UbicacionFisica {get; set;} = string.Empty;
    public int CantidadTotal {get; set;}
    public int CantidadDisponible {get; set;}
    
    //public List<Prestamo> Prestamos {get; set;} = new();

    /* EL CONTRUCTOR POR EL MOMENTO NO SERIA NECESARIO
    public Libro(string titulo, string autor, string isbn, string editorial, int anioPublicacion, string ubicacionFisica, int cantidadTotal, int cantidadDisponible)
    {
        Titulo = titulo;
        Autores = autor;
        ISBN = isbn;
        Editorial = editorial;
        AnioPublicacion = anioPublicacion;
        UbicacionFisica = ubicacionFisica;
        CantidadTotal = cantidadTotal;
        CantidadDisponible = cantidadDisponible;
    }*/
}