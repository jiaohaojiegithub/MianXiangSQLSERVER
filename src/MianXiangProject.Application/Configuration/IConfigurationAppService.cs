using System.Threading.Tasks;
using MianXiangProject.Configuration.Dto;

namespace MianXiangProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
