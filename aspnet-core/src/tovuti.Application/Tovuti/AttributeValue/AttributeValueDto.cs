using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Engine.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Application
{
    [AutoMapFrom(typeof(AttributeValue))]
    public class AttributeValueDto : EntityDto
    {
        public Attribute Attribute { get; set; }

        public int AttributeId { get; set; }

        public string ValueName { get; set; }

        public string ValueDescription { get; set; }
    }

    [AutoMapTo(typeof(AttributeValue))]
    public class InputAttributeValueDto : EntityDto
    {
        public int AttributeId { get; set; }

        public string ValueName { get; set; }

        public string ValueDescription { get; set; }
    }

    public class PagedAttributeValueResultRequestDto : PagedResultRequestDto
    {
        public string FilterText { get; set; }
    }
}