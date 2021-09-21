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
    public class AttributeValueAppService : AsyncCrudAppService<AttributeValue, AttributeValueDto, int, PagedAttributeValueResultRequestDto, InputAttributeValueDto, InputAttributeValueDto>, IAttributeValueAppService
    {
        private readonly IRepository<AttributeValue, int> _attributeValueRepository;
        public AttributeValueAppService(IRepository<AttributeValue> attributeValueRepository) : base(attributeValueRepository)
        {
            _attributeValueRepository = attributeValueRepository;
        }

        public override async Task<PagedResultDto<AttributeValueDto>> GetAllAsync(PagedAttributeValueResultRequestDto input)
        {
            var _listResponse = new List<AttributeValue>();
            try
            {
                _listResponse = await _attributeValueRepository
                    .GetAll()
                    .Include(p => p.Attribute)
                    .WhereIf(input.FilterText != null, x => x.ValueName == input.FilterText)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new UserFriendlyException("Exception on AttributeValue GetAllAsync: " + e.Message);
            }
            return new PagedResultDto<AttributeValueDto>(_listResponse.Count(), ObjectMapper.Map<List<AttributeValueDto>>(_listResponse));
        }
    }
}
