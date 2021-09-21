using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Engine.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engine.Application
{
    public class ProductAppService : AsyncCrudAppService<Product, ProductDto, int, PagedProductResultRequestDto, InputProductDto, InputProductDto>, IProductAppService
    {
        private IRepository<Product, int> _productRepository;
        public ProductAppService(IRepository<Product> productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        //overide getAll method to implement filtering for products
        public override async Task<PagedResultDto<ProductDto>> GetAllAsync(PagedProductResultRequestDto input)
        {
            var _listResponse = new List<Product>();
            try
            {
                _listResponse = await _productRepository
                    .GetAll()
                    .Include(p => p.TypeOfProduct)
                    .WhereIf(input.FilterText != null, x => x.TypeOfProduct.ProductTypeName == input.FilterText)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new UserFriendlyException("Exception on Product GetAllAsync: " + e.Message);
            }
            return new PagedResultDto<ProductDto>(_listResponse.Count(), ObjectMapper.Map<List<ProductDto>>(_listResponse));
        }
    }
}
