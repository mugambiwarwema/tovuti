using Abp.Application.Services;

namespace Engine.Application
{
    public interface IProductAppService : IAsyncCrudAppService<ProductDto, int, PagedProductResultRequestDto, InputProductDto, InputProductDto>
    { }
}
