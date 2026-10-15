using System.ComponentModel.DataAnnotations;

namespace PanaderiaV2.Web.DTOs.Product
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(32, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(128, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres.")]
        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
       
        [Display(Name = "Precio")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Cantidad Disp")]
        public int stock { get; set; }

        public bool IsHidden { get; set; } = false;
    }
}
