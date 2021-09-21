using Abp.Application.Services;

namespace Engine.Application
{
    public interface IProductTypeAttributeValueAppService : IAsyncCrudAppService<ProductTypeAttributeValueDto, int, PagedProductTypeAttributeValueResultRequestDto, InputProductTypeAttributeValueDto, InputProductTypeAttributeValueDto>
    { }
}
