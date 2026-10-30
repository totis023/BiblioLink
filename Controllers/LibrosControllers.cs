using BiblioLink.DTOs;
using BiblioLink.Exceptions;
using BiblioLink.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BiblioLink.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly ILibroService _servicio;

    public LibrosController(ILibroService servicio)
    {
        _servicio = servicio;
    }

    [HttpGet] //GET /api/libros
    public async Task<ActionResult<IEnumerable<LibroReadDTO>>> GetAll() => Ok(await _servicio.GetAll());

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LibroReadDTO>> GetById(int id)
    {
        try
        {
            return Ok(await _servicio.GetById(id));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // PUT /api/libros/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<LibroReadDTO>> Update(int id, [FromBody] LibroUpdateDTO dto)
    {
        try
        {
            return Ok(await _servicio.Update(id, dto));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ReglaNegocioException ex)
        {
            return Conflict(ex.Message);
        }
    }

    // DELETE /api/libros/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _servicio.Delete(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ReglaNegocioException ex)
        {
            return Conflict(ex.Message);
        }
    }
}