using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MianXiangProject.Configuration;

namespace MianXiangProject.Web.Host.Startup
{
    [DependsOn(
       typeof(MianXiangProjectWebCoreModule))]
    public class MianXiangProjectWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MianXiangProjectWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MianXiangProjectWebHostModule).GetAssembly());
        }
    }
}
