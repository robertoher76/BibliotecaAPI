using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.DTO
{
    public class EditorialDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El nombre de la editorial es requerido")]
        [StringLength(50, ErrorMessage = "El nombre de la editorial no puede tener más de 50 caracteres.")]
        public string NombreEditorial { get; set; } = string.Empty;
    }
}
