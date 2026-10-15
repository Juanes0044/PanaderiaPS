using PanaderiaV2.Web.Data.Abstractions;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PanaderiaV2.Web.Data.Entities
{
    public class Product : IId
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(32)]
        public required string Name { get; set; }

        [MaxLength(50)]
        public required string Description { get; set; }

        [Precision(18, 2)]
        public int stock { get; set; }

        [Precision(18, 2)]
        public decimal price { get; set; }


        public bool IsHidden { get; set; }
    }
}
