using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MianXiangProject.EntityFrameworkCore
{
    public static class MianXiangProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MianXiangProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MianXiangProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
