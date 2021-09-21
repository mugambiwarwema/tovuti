using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Core
{
    [Table("tovuti_Products")]
    public class Product : Entity<int>
    {
        [ForeignKey(nameof(ProductTypeId))]
        public ProductType TypeOfProduct { get; set; }
        public int ProductTypeId { get; set; }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }

    }
}
