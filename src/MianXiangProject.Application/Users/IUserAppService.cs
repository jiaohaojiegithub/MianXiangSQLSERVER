using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MianXiangProject.Roles.Dto;
using MianXiangProject.Users.Dto;

namespace MianXiangProject.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
