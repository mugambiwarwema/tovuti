using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Engine.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Application
{
    [AutoMapFrom(typeof(ProductType))]
    public class ProductTypeDto : EntityDto
    {
        public string ProductTypeName { get; set; }
        public string ProductTypeDescription { get; set; }
    }

    [AutoMapTo(typeof(ProductType))]
    public class InputProductTypeDto : EntityDto
    {
        public string ProductTypeName { get; set; }
        public string ProductTypeDescription { get; set; }
    }

    public class PagedProductTypeResultRequestDto : PagedResultRequestDto
    {
        public string FilterText { get; set; }
    }
}