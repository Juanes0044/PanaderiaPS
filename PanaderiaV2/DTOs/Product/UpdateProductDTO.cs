using System.ComponentModel.DataAnnotations;

namespace PanaderiaV2.Web.DTOs.Product
{
    public class UpdateProductDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(32, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(128, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public decimal price { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
 
        public int stock { get; set; }

        public bool IsHidden { get; set; }
    }
}
