using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Entities.DTO
{
    public class LibroDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string NombreLibro { get; set; } = string.Empty;

        //propiedad para la llave foranea        
        [Required]
        [ForeignKey("Autor")]
        public int? CodigoAutorLibro { get; set; }

        //propiedad para la llave foranea        
        [Required]
        [ForeignKey("Editorial")]
        public int? CodigoEditorialLibro { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo fecha de lanzamiento es requerido")]
        public DateTime FechaLanzamientoLibro { get; set; }
    }
}
