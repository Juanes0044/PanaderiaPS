using System.ComponentModel.DataAnnotations;

namespace Panaderia.web.DTOs
{
    public class ToggleProductStatusDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public Guid Id { get; set; }
        public bool Hide { get; set; } = true;
    }
}
