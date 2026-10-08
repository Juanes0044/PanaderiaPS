using System.ComponentModel.DataAnnotations;
namespace Panaderia.web.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64,ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

      
        public decimal Price { get; set; }
        public int stock { get; set; }

      


    }
}
