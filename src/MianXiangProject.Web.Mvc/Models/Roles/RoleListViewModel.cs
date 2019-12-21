using System.Collections.Generic;
using MianXiangProject.Roles.Dto;

namespace MianXiangProject.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleListDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
