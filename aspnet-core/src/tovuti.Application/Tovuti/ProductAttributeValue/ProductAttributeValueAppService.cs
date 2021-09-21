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
    public class ProductAttributeValueAppService : AsyncCrudAppService<ProductAttributeValue, ProductAttributeValueDto, int, PagedProductAttributeValueResultRequestDto, InputProductAttributeValueDto, InputProductAttributeValueDto>, IProductAttributeValueAppService
    {
        private IRepository<ProductAttributeValue, int> _productAttributeValueRepository;
        public ProductAttributeValueAppService(IRepository<ProductAttributeValue> productAttributeValueRepository) : base(productAttributeValueRepository)
        {
            _productAttributeValueRepository = productAttributeValueRepository;
        }

        //overide getAll method to implement filtering
        public override async Task<PagedResultDto<ProductAttributeValueDto>> GetAllAsync(PagedProductAttributeValueResultRequestDto input)
        {
            var _listResponse = new List<ProductAttributeValue>();
            try
            {
                _listResponse = await _productAttributeValueRepository
                    .GetAll()
                    .Include(p => p.AttributeValue)
                    .Include(p => p.Product)
                    .WhereIf(input.FilterText != null, x => x.Product.ProductName == input.FilterText)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new UserFriendlyException("Exception on ProductAttributeValue GetAllAsync: " + e.Message);
            }
            return new PagedResultDto<ProductAttributeValueDto>(_listResponse.Count(), ObjectMapper.Map<List<ProductAttributeValueDto>>(_listResponse));
        }
    }
}
