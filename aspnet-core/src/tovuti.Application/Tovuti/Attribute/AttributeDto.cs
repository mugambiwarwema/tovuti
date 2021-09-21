using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Engine.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Application
{
    [AutoMapFrom(typeof(Attribute))]
    public class AttributeDto : EntityDto
    {
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }
    }

    [AutoMapTo(typeof(Attribute))]
    public class InputAttributeDto : EntityDto
    {
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }
    }

    public class PagedAttributeResultRequestDto : PagedResultRequestDto
    {
        public string FilterText { get; set; }
    }
}