using Abp.AspNetCore.Mvc.ViewComponents;

namespace MianXiangProject.Web.Views
{
    public abstract class MianXiangProjectViewComponent : AbpViewComponent
    {
        protected MianXiangProjectViewComponent()
        {
            LocalizationSourceName = MianXiangProjectConsts.LocalizationSourceName;
        }
    }
}
