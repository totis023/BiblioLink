namespace BiblioLink.Exceptions;

//NotFoundException	el libro pedido no existe (404 Not Found)
public class ReglaNegocioException : Exception
{
    public ReglaNegocioException(string mensaje) : base(mensaje) { }
}