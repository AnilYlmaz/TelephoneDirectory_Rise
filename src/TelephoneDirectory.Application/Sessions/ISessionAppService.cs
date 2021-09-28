using System.Threading.Tasks;
using Abp.Application.Services;
using TelephoneDirectory.Sessions.Dto;

namespace TelephoneDirectory.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
