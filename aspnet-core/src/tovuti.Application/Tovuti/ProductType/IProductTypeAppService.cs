using Abp.Application.Services;

namespace Engine.Application
{
    public interface IProductTypeAppService : IAsyncCrudAppService<ProductTypeDto, int, PagedProductTypeResultRequestDto, InputProductTypeDto, InputProductTypeDto>
    { }
}
