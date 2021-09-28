using System.Threading.Tasks;
using TelephoneDirectory.Configuration.Dto;

namespace TelephoneDirectory.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
