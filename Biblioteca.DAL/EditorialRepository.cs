using Biblioteca.DAL.Interfaces;
using Dapper;
using Biblioteca.Entities.Models;

namespace Biblioteca.DAL
{
    internal class EditorialRepository : IEditorialRepository
    {
        private readonly IDatabaseRepository databaseRepository;

        public EditorialRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        public async Task<List<Editorial>> GetEditorialesAsync()
        {
            string query = "SELECT * FROM Editoriales";
            return await databaseRepository.GetDataByQueryAsync<Editorial>(query);
        }

        public async Task<Editorial> GetEditorialByIdAsync(int id)
        {
            string query = "SELECT * FROM Editoriales WHERE id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Editorial>(query, parameters)).FirstOrDefault();
        }

        public async Task<int> InsertEditorialAsync(Editorial editorial)
        {
            string query = "INSERT INTO Editoriales (Nombre) VALUES (@Nombre); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", editorial.Nombre);
            return await databaseRepository.InsertAsync(query, parameters);
        }

        public async Task<Editorial> UpdateEditorialAsync(Editorial editorial)
        {
            string query = "UPDATE Editoriales SET Nombre = @Nombre WHERE id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", editorial.id);
            parameters.Add("@Nombre", editorial.Nombre);           
            await databaseRepository.UpdateAsync<Editorial>(query, parameters);
            return editorial;
        }

        public async Task<bool> DeleteEditorialAsync(int id)
        {
            string query = "DELETE FROM Editoriales WHERE id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync(query, parameters);
        }
    }
}