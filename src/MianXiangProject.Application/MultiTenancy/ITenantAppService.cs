using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MianXiangProject.MultiTenancy.Dto;

namespace MianXiangProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

