
using System.ComponentModel.DataAnnotations;

namespace Panaderia.web.DTOs
{
    public class CreateSupplierDTO
    {
        [MaxLength (64, ErrorMessage = "El campo {0} de tener maximo {1} caracteres. ")]
        [Required(ErrorMessage =" El campo {0} es obligatorio")]
        public string Name { get; set;  }

        [MaxLength(20, ErrorMessage = "El campo {0} de tener maximo {1} caracteres. ")]
        [Required(ErrorMessage = " El campo {0} es obligatorio")]
        public string Phone { get; set; }

        [MaxLength(64, ErrorMessage = "El campo {0} de tener maximo {1} caracteres. ")]
        [EmailAddress(ErrorMessage ="El campo {0} no es un correo valido")]
        [Required(ErrorMessage = " El campo {0} es obligatorio")]
        public string Email { get; set; }
    }
}
