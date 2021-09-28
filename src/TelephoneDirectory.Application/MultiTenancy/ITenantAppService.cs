using Abp.Application.Services;
using TelephoneDirectory.MultiTenancy.Dto;

namespace TelephoneDirectory.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

