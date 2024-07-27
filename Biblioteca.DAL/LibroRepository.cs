using Biblioteca.DAL.Interfaces;
using Dapper;
using Biblioteca.Entities.Models;

namespace Biblioteca.DAL
{
    internal class LibroRepository : ILibroRepository
    {
        private readonly IDatabaseRepository databaseRepository;

        public LibroRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        public async Task<List<Libro>> GetLibrosAsync()
        {
            string query = "SELECT * FROM Libros";
            return await databaseRepository.GetDataByQueryAsync<Libro>(query);
        }

        public async Task<Libro> GetLibroByIdAsync(int id)
        {
            string query = "SELECT * FROM Libros WHERE id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Libro>(query, parameters)).FirstOrDefault();
        }

        public async Task<int> InsertLibroAsync(Libro libro)
        {
            string query = "INSERT INTO Libros (Nombre, CodigoAutor, CodigoEditorial, FechaDeLanzamiento) VALUES (@Nombre, @CodigoAutor, @CodigoEditorial, @FechaDeLanzamiento); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", libro.Nombre);
            parameters.Add("@CodigoAutor", libro.CodigoAutor);
            parameters.Add("@CodigoEditorial", libro.CodigoEditorial);
            parameters.Add("@FechaDeLanzamiento", libro.FechaDeLanzamiento);
            return await databaseRepository.InsertAsync(query, parameters);
        }

        public async Task<Libro> UpdateLibroAsync(Libro libro)
        {
            string query = "UPDATE Libros SET Nombre = @Nombre, CodigoAutor = @CodigoAutor, CodigoEditorial = @CodigoEditorial, FechaDeLanzamiento = @FechaDeLanzamiento WHERE id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", libro.id);
            parameters.Add("@Nombre", libro.Nombre);
            parameters.Add("@CodigoAutor", libro.CodigoAutor);
            parameters.Add("@CodigoEditorial", libro.CodigoEditorial);
            parameters.Add("@FechaDeLanzamiento", libro.FechaDeLanzamiento);
            await databaseRepository.UpdateAsync<Editorial>(query, parameters);
            return libro;
        }

        public async Task<bool> DeleteLibroAsync(int id)
        {
            string query = "DELETE FROM Libros WHERE id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync(query, parameters);
        }
    }
}