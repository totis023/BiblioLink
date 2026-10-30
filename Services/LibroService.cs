using BiblioLink.DTOs;
using BiblioLink.Exceptions;
using BiblioLink.Interfaces;
using BiblioLink.Models;
using Microsoft.EntityFrameworkCore;

namespace BiblioLink.Services;

public class LibroService : ILibroService
{
    private readonly BibliotecaContext _db;
    private readonly ILogger<LibroService> _logger;

    public LibroService(BibliotecaContext db, ILogger<LibroService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<IEnumerable<LibroReadDTO>> GetAll()
    {
        var libros = await _db.Libros.AsNoTracking().OrderBy(l => l.Titulo).ToListAsync();
        return libros.Select(Mapear).ToList();
    }

    public async Task<LibroReadDTO> GetById(int id)
    {
        var libro = await _db.Libros.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id) ?? throw new NotFoundException($"No se encontró el libro con ID {id}.");
        return Mapear(libro);
    }

    public async Task<LibroReadDTO> Create(LibroCreateDTO dto)
    {
        var isbn = dto.ISBN.Trim();

        if(await _db.Libros.AnyAsync(l => l.ISBN == isbn))
        {
            _logger.LogWarning("Alta rechazada: ya existe un libro con ISBN {ISBN}", isbn);
            throw new ReglaNegocioException($"Ya existe un libro con el ISBN {isbn}.");
        }

        var libro = new Libro
        {
            Titulo = dto.Titulo,
            Autores = dto.Autores,
            ISBN = isbn,
            Editorial = dto.Editorial,
            AnioPublicacion = dto.AnioPublicacion,
            UbicacionFisica = dto.UbicacionFisica,
            CantidadTotal = dto.CantidadTotal,
            CantidadDisponible = dto.CantidadTotal
        };

        _db.Libros.Add(libro);
        await _db.SaveChangesAsync();

        _logger.LogInformation("Libro creado {LibroId} (ISBN {ISBN})", libro.Id, libro.ISBN);
        return Mapear(libro);
    }
    public async Task<LibroReadDTO> Update(int id, LibroUpdateDTO dto)
    {
        var libro = await _db.Libros.FindAsync(id) ?? throw new NotFoundException($"No se encontró el libro con ID {id}.");

        var isbn = dto.ISBN.Trim();

        if(await _db.Libros.AnyAsync(l => l.ISBN == isbn && l.Id != id)) throw new ReglaNegocioException($"Ya existe otro libro con el ISBN {isbn}.");
        
        var prestados = libro.CantidadTotal - libro.CantidadDisponible;

        if(dto.CantidadTotal < prestados) throw new ReglaNegocioException($"No se puede fijar la cantidad total en {dto.CantidadTotal}: hay {prestados} ejemplares prestados.");

        libro.Titulo = dto.Titulo;
        libro.Autores = dto.Autores;
        libro.ISBN = isbn;
        libro.Editorial = dto.Editorial;
        libro.AnioPublicacion = dto.AnioPublicacion;
        libro.UbicacionFisica = dto.UbicacionFisica;
        libro.CantidadTotal = dto.CantidadTotal;
        libro.CantidadDisponible = dto.CantidadTotal - prestados;

        await _db.SaveChangesAsync();

        _logger.LogInformation("Libro actualizado {LibroId}", libro.Id);
        return Mapear(libro);
    }
    public async Task Delete(int id)
    {
        var libro = await _db.Libros.FindAsync(id) ?? throw new NotFoundException($"No se encontró el libro con ID {id}.");

        if(libro.CantidadDisponible < libro.CantidadTotal) throw new ReglaNegocioException("No se puede eliminar un libro con ejemplares prestados.");

        //TODO (cuando exista Prestamo): impedir borrar libros con historial de prestamos

        _db.Libros.Remove(libro);
        await _db.SaveChangesAsync();

        _logger.LogInformation("Libro eliminado {LibroId}", id);
    }

    private static LibroReadDTO Mapear(Libro l) => new ()
    {
        Id = l.Id,
        Titulo = l.Titulo,
        Autores = l.Autores,
        ISBN = l.ISBN,
        Editorial = l.Editorial,
        AnioPublicacion = l.AnioPublicacion,
        UbicacionFisica = l.UbicacionFisica,
        CantidadTotal = l.CantidadTotal,
        CantidadDisponible = l.CantidadDisponible
    };
}