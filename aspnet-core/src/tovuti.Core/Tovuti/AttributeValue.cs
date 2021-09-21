using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Core
{
    [Table("tovuti_AttributeValues")]
    public class AttributeValue : Entity<int>
    {

        [ForeignKey(nameof(AttributeId))]
        public Attribute Attribute { get; set; }
        public int AttributeId { get; set; }

        public string ValueName { get; set; }
        public string ValueDescription { get; set; }
    }
}
