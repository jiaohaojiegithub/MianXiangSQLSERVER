using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MianXiangProject.Authorization;

namespace MianXiangProject
{
    [DependsOn(
        typeof(MianXiangProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MianXiangProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MianXiangProjectAuthorizationProvider>();
         
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MianXiangProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
