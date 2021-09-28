using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.MembersAppService.Dto;

namespace TelephoneDirectory.MembersAppService
{
    public interface IMembersService : IApplicationService
    {
        Task<ListResultDto<MembersDto>> GetMembers();

        Task<Guid> AddMembers(MembersDto input);

        Task UpdateMembers(MembersDto input);

        Task<MembersDto> FindMembers(Guid id);

        Task DeleteMembers(Guid id);
    }
}
