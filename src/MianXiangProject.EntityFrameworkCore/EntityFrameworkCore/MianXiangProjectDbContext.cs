using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MianXiangProject.Authorization.Roles;
using MianXiangProject.Authorization.Users;
using MianXiangProject.MultiTenancy;
using MianXiangProject.DataTables;

namespace MianXiangProject.EntityFrameworkCore
{
    public class MianXiangProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MianXiangProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<MXJob> MXJob { get; set; }
        public virtual DbSet<MXCompany> MXCompany { get; set; }
        public virtual DbSet<MXQuestion> MXQuestion { get; set; }
        public virtual DbSet<MXAttribute> MXAttribute { get; set; }
        public virtual DbSet<WxAppletUser> WxAppletUser { get; set; }
        public virtual DbSet<WxUserInfo> WxUserInfo { get; set; }
        public MianXiangProjectDbContext(DbContextOptions<MianXiangProjectDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MXJob>(entity =>
            {
                entity.Property(e => e.State).HasConversion<int>();//预定义的转换
                entity.Property(e => e.CreationTime)
                .ValueGeneratedOnAdd();
                // .HasDefaultValue(Clock.Now);
            });
            modelBuilder.Entity<MXCompany>(entity =>
            {
                entity.Property(e => e.State).HasConversion<int>();//预定义的转换
                entity.Property(e => e.CreationTime)
                .ValueGeneratedOnAdd();
                // .HasDefaultValue(Clock.Now);
            });
            modelBuilder.Entity<MXQuestion>(entity =>
            {
                entity.Property(e => e.State).HasConversion<int>();//预定义的转换
                entity.Property(e => e.QuestionType).HasConversion<string>();//预定义的转换
                entity.Property(e => e.Question).HasColumnType("text");//数据类型text
                entity.Property(e => e.Answer).HasColumnType("text");
                entity.Property(e => e.CreationTime)
                .ValueGeneratedOnAdd();
            });
        }
    }
}
