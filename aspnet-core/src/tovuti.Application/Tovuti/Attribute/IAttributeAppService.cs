using Abp.Application.Services;

namespace Engine.Application
{
    public interface IAttributeAppService : IAsyncCrudAppService<AttributeDto, int, PagedAttributeResultRequestDto, InputAttributeDto, InputAttributeDto>
    { }
}
