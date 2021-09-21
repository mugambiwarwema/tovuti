using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Engine.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Application
{
    [AutoMapFrom(typeof(Product))]
    public class ProductDto : EntityDto
    {
        public ProductType TypeOfProduct { get; set; }
        public int ProductTypeId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }
    }

    [AutoMapTo(typeof(Product))]
    public class InputProductDto : EntityDto
    {
        public int ProductTypeId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }
    }

    public class PagedProductResultRequestDto : PagedResultRequestDto
    {
        public string FilterText { get; set; }
    }
}