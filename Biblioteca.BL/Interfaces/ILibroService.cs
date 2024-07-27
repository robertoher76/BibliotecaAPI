using Biblioteca.Entities.DTO;

namespace Biblioteca.BL.Interfaces
{
    public interface ILibroService
    {
        public Task<List<LibroDto>> GetLibrosAsync();
        public Task<LibroDto> GetLibroByIdAsync(int id);
        public Task<int> InsertLibroAsync(LibroDto editorial);
        public Task<LibroDto> UpdateLibroAsync(LibroDto editorial);
        public Task<bool> DeleteLibroAsync(int id);
    }
}
