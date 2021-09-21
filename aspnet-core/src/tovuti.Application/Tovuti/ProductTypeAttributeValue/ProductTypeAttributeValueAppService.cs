using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Engine.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engine.Application
{
    public class ProductTypeAttributeValueAppService : AsyncCrudAppService<ProductTypeAttributeValue, ProductTypeAttributeValueDto, int, PagedProductTypeAttributeValueResultRequestDto, InputProductTypeAttributeValueDto, InputProductTypeAttributeValueDto>, IProductTypeAttributeValueAppService
    {
        private IRepository<ProductTypeAttributeValue, int> _productTypeAttributeValueRepository;
        public ProductTypeAttributeValueAppService(IRepository<ProductTypeAttributeValue> productTypeAttributeValueRepository) : base(productTypeAttributeValueRepository)
        {
            _productTypeAttributeValueRepository = productTypeAttributeValueRepository;
        }

        //overide getAll method to implement filtering for products
        public override async Task<PagedResultDto<ProductTypeAttributeValueDto>> GetAllAsync(PagedProductTypeAttributeValueResultRequestDto input)
        {
            var _listResponse = new List<ProductTypeAttributeValue>();
            try
            {
                _listResponse = await _productTypeAttributeValueRepository
                    .GetAll()
                    .Include(p => p.TypeOfProduct)
                    .Include(p => p.ValueOfAttribute)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new UserFriendlyException("Exception on ProductTypeAttributeValue GetAllAsync: " + e.Message);
            }
            return new PagedResultDto<ProductTypeAttributeValueDto>(_listResponse.Count(), ObjectMapper.Map<List<ProductTypeAttributeValueDto>>(_listResponse));
        }
    }
}
