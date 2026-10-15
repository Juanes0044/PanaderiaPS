using System.ComponentModel.DataAnnotations;

namespace PanaderiaV2.Web.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = null!;
        public int stock { get; set; }
        public decimal price { get; set; }

        public bool IsHidden { get; set; } = false;
    }
}