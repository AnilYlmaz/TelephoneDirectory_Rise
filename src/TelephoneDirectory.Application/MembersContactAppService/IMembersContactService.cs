using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.MembersContactAppService.Dto;

namespace TelephoneDirectory.MembersContactAppService
{
    public interface IMembersContactService : IApplicationService
    {
        Task<ListResultDto<MembersContactDto>> GetMembersContact();
        Task<int> GetMembersLocationReport(string location);
        Task<int> GetPhoneNumbersLocationReport(string location);
        Task<Guid> AddMembersContact(MembersContactDto input);
        Task UpdateMembersContact(MembersContactDto input);
        Task<MembersContactDto> FindMembersContact(Guid id);
        Task DeleteMembersContact(Guid id);
    }
}
