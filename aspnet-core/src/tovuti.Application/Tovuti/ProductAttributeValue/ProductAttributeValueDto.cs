using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Engine.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Application
{
    [AutoMapFrom(typeof(ProductAttributeValue))]
    public class ProductAttributeValueDto : EntityDto
    {
        public AttributeValue AttributeValue { get; set; }
        public int AttributeValueId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }

    [AutoMapTo(typeof(ProductAttributeValue))]
    public class InputProductAttributeValueDto : EntityDto
    {
        public int AttributeValueId { get; set; }

        public int ProductId { get; set; }
    }

    public class PagedProductAttributeValueResultRequestDto : PagedResultRequestDto
    {
        public string FilterText { get; set; }
    }
}