using System.ComponentModel.DataAnnotations;
namespace Panaderia.web.Data.Entities
{
    public class ProductDTO
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        public int stock { get; set; }




    }
}
