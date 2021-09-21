using Abp.Application.Services;

namespace Engine.Application
{
    public interface IProductAttributeValueAppService : IAsyncCrudAppService<ProductAttributeValueDto, int, PagedProductAttributeValueResultRequestDto, InputProductAttributeValueDto, InputProductAttributeValueDto>
    { }
}
