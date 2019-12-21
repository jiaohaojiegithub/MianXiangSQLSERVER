using System.Collections.Generic;
using MianXiangProject.Roles.Dto;
using MianXiangProject.Users.Dto;

namespace MianXiangProject.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
