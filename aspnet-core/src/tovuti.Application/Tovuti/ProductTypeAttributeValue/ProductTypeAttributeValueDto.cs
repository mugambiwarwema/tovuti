using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Engine.Core;

namespace Engine.Application
{
    [AutoMapFrom(typeof(ProductTypeAttributeValue))]
    public class ProductTypeAttributeValueDto : EntityDto
    {
        public ProductType TypeOfProduct { get; set; }
        public int ProductTypeId { get; set; }

        public AttributeValue ValueOfAttribute { get; set; }
        public int AttributeValueId { get; set; }
    }

    [AutoMapTo(typeof(ProductTypeAttributeValue))]
    public class InputProductTypeAttributeValueDto : EntityDto
    {
        public ProductType TypeOfProduct { get; set; }
        public int ProductTypeId { get; set; }

        public AttributeValue ValueOfAttribute { get; set; }
        public int AttributeValueId { get; set; }
    }

    public class PagedProductTypeAttributeValueResultRequestDto : PagedResultRequestDto
    {
        public string FilterText { get; set; }
    }
}