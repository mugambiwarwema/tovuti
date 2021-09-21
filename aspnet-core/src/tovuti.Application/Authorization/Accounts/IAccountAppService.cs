using System.Threading.Tasks;
using Abp.Application.Services;
using tovuti.Authorization.Accounts.Dto;

namespace tovuti.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
