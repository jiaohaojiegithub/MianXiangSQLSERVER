using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MianXiangProject.EntityFrameworkCore
{
    public static class MianXiangProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MianXiangProjectDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MianXiangProjectDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
