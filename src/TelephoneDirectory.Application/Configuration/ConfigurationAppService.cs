using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TelephoneDirectory.Configuration.Dto;

namespace TelephoneDirectory.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TelephoneDirectoryAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
