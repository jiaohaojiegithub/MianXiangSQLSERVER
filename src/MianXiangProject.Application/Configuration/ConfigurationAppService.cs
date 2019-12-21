using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MianXiangProject.Configuration.Dto;

namespace MianXiangProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MianXiangProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
