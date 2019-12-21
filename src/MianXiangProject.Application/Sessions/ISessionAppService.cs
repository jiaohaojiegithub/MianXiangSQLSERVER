using System.Threading.Tasks;
using Abp.Application.Services;
using MianXiangProject.Sessions.Dto;

namespace MianXiangProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
