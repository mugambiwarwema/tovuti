using System.Threading.Tasks;
using tovuti.Configuration.Dto;

namespace tovuti.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
