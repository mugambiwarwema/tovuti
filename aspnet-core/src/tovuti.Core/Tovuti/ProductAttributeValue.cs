
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Core
{
    [Table("tovuti_ProductAttributeValues")]
    public class ProductAttributeValue : Entity<int>
    {
        [ForeignKey(nameof(AttributeValueId))]
        public AttributeValue AttributeValue { get; set; }
        public int AttributeValueId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
