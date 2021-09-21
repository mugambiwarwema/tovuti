using Abp.Application.Services;
using tovuti.MultiTenancy.Dto;

namespace tovuti.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

