using Abp.Authorization;
using MianXiangProject.Authorization.Roles;
using MianXiangProject.Authorization.Users;

namespace MianXiangProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
