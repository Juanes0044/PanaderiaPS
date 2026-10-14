using Panaderia.web.Data.Abstractions;
using System.ComponentModel.DataAnnotations;
namespace Panaderia.web.Data.Entities
{
    public class Product : IId
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(64,ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

      
        public decimal Price { get; set; }
        public int stock { get; set; }

      


    }
}
