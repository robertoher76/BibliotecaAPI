using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.Models
{
    public class Libro
    {
        [Key]
        public int id { get; set; }        

        public required string Nombre { get; set; }

        public required int CodigoAutor { get; set; }

        public required int CodigoEditorial { get; set; }

        public required DateTime FechaDeLanzamiento { get; set; }
    }
}
