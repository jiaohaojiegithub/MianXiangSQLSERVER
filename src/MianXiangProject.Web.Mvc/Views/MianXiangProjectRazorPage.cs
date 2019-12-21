using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace MianXiangProject.Web.Views
{
    public abstract class MianXiangProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MianXiangProjectRazorPage()
        {
            LocalizationSourceName = MianXiangProjectConsts.LocalizationSourceName;
        }
    }
}
