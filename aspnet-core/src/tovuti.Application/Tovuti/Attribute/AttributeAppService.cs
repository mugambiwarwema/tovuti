using Abp.Application.Services;
using Abp.Domain.Repositories;
using Engine.Core;

namespace Engine.Application
{
    public class AttributeAppService : AsyncCrudAppService<Attribute, AttributeDto, int, PagedAttributeResultRequestDto, InputAttributeDto, InputAttributeDto>, IAttributeAppService
    {
        public AttributeAppService(IRepository<Attribute> attributeRepository) : base(attributeRepository)
        { }
    }
}
