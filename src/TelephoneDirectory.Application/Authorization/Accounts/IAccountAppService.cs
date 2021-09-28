using System.Threading.Tasks;
using Abp.Application.Services;
using TelephoneDirectory.Authorization.Accounts.Dto;

namespace TelephoneDirectory.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
