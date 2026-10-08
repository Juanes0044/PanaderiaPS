using System.ComponentModel.DataAnnotations;


namespace Panaderia.web.DTOs
{
    public class CreateProductDTO
    {
        [MaxLength(64, ErrorMessage = "El nombre del producto no puede tener más de 64 caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
