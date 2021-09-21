using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Core
{
    [Table("tovuti_ProductTypeAttributeValues")]
    public class ProductTypeAttributeValue : Entity<int>
    {
        [ForeignKey(nameof(ProductTypeId))]
        public ProductType TypeOfProduct { get; set; }
        public int ProductTypeId { get; set; }

        [ForeignKey(nameof(AttributeValueId))]
        public AttributeValue ValueOfAttribute { get; set; }
        public int AttributeValueId { get; set; }
    }
}
