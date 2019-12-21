using System.Threading.Tasks;
using Abp.Application.Services;
using MianXiangProject.Authorization.Accounts.Dto;

namespace MianXiangProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
