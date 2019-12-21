using Abp.Application.Navigation;
using Abp.Localization;
using MianXiangProject.Authorization;

namespace MianXiangProject.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class MianXiangProjectNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "business",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                )
                 .AddItem(
                    new MenuItemDefinition(
                        "DataManage",
                        L("DataManage"),
                        icon: "menu"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.MXAttribute,
                        L("MXAttribute"),
                        url: "MXAttribute"
                        )).AddItem(new MenuItemDefinition(
                        PageNames.MXJob,
                        L("MXJob"),
                        url: "MXJob"
                        )).AddItem(new MenuItemDefinition(
                        PageNames.MXCompany,
                        L("MXCompany"),
                        url: "MXCompany"
                        ))
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MianXiangProjectConsts.LocalizationSourceName);
        }
    }
}
