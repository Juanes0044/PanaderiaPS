using System.ComponentModel.DataAnnotations;

namespace PanaderiaV2.Web.DTOs.Product
{
    public class ToggleProductStatusDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid ProductId { get; set; }

        public bool Hide { get; set; } = true;
    }
}
