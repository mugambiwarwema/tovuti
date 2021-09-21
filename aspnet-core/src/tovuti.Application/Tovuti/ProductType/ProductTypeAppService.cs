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
    public class ProductTypeAppService : AsyncCrudAppService<ProductType, ProductTypeDto, int, PagedProductTypeResultRequestDto, InputProductTypeDto, InputProductTypeDto>, IProductTypeAppService
    {
        private IRepository<ProductType, int> _productTypeRepository;
        public ProductTypeAppService(IRepository<ProductType> productTypeRepository) : base(productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        //overide getAll method to implement filtering for products
        public override async Task<PagedResultDto<ProductTypeDto>> GetAllAsync(PagedProductTypeResultRequestDto input)
        {
            var _listResponse = new List<ProductType>();
            try
            {
                _listResponse = await _productTypeRepository
                    .GetAll()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new UserFriendlyException("Exception on ProductType GetAllAsync: " + e.Message);
            }
            return new PagedResultDto<ProductTypeDto>(_listResponse.Count(), ObjectMapper.Map<List<ProductTypeDto>>(_listResponse));
        }
    }
}
