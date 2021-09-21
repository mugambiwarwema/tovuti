using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using tovuti.Configuration.Dto;

namespace tovuti.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : tovutiAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
