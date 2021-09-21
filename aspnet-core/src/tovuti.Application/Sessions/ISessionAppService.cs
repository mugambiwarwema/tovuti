using System.Threading.Tasks;
using Abp.Application.Services;
using tovuti.Sessions.Dto;

namespace tovuti.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
