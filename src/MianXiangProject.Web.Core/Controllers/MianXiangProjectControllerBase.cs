using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MianXiangProject.Controllers
{
    public abstract class MianXiangProjectControllerBase: AbpController
    {
        protected MianXiangProjectControllerBase()
        {
            LocalizationSourceName = MianXiangProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
