using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MianXiangProject.Configuration;
using MianXiangProject.Web;

namespace MianXiangProject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MianXiangProjectDbContextFactory : IDesignTimeDbContextFactory<MianXiangProjectDbContext>
    {
        public MianXiangProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MianXiangProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MianXiangProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MianXiangProjectConsts.ConnectionStringName));

            return new MianXiangProjectDbContext(builder.Options);
        }
    }
}
