using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.Models
{
    public class Editorial
    {
        [Key]
        public int id { get; set; }

        public required string Nombre { get; set; }
    }
}
