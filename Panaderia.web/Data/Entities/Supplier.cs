
using System.ComponentModel.DataAnnotations;


namespace Panaderia.web.Data.Entities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(64, ErrorMessage = "El campo {0} debe ser maximo de {1] caracteres} ")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Name { get; set; }


        [MaxLength(20, ErrorMessage = "El campo {0} debe ser maximo de {1] caracteres} ")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Phone { get; set; }


        [MaxLength(64, ErrorMessage = "El campo {0} debe ser maximo de {1] caracteres} ")]
        [EmailAddress(ErrorMessage = "El campo {0} no es un correo valido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Emial { get; set; }

    }
}
