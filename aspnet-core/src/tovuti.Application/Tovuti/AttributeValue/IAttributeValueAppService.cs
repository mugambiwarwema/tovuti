using Abp.Application.Services;

namespace Engine.Application
{
    public interface IAttributeValueAppService : IAsyncCrudAppService<AttributeValueDto, int, PagedAttributeValueResultRequestDto, InputAttributeValueDto, InputAttributeValueDto>
    { }
}
