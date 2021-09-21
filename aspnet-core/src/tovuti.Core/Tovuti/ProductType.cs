using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Engine.Core
{
    [Table("tovuti_ProductTypes")]
    public class ProductType : Entity<int>
    {
        public string ProductTypeName { get; set; }
        public string ProductTypeDescription { get; set; }
    }
}
