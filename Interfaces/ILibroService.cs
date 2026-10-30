using BiblioLink.DTOs;

namespace BiblioLink.Interfaces;

public interface ILibroService
{
    Task<IEnumerable<LibroReadDTO>> GetAll();
    Task<LibroReadDTO> GetById(int id);
    Task<LibroReadDTO> Create(LibroCreateDTO dto);
    Task<LibroReadDTO> Update(int id, LibroUpdateDTO dto);
    Task Delete(int id);
}