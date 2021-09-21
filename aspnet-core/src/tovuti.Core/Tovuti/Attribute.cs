using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Core
{
    [Table("tovuti_Attributes")]
    public class Attribute : Entity<int>
    {
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }
    }
}