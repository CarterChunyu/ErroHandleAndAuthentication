using ErrorHandlerandAuthetication.Models;
using Microsoft.EntityFrameworkCore;

namespace ErrorHandlerandAuthetication.DBContexts
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = 1,
                    UserName = "chunyu",
                    Account = "tnfe01",
                    Password = "@a0123456789",
                    GroupId = "T001"
                },
                new User()
                {
                    UserId = 2,
                    UserName = "dru",
                    Account = "tnfe02",
                    Password = "@a0123456789",
                    GroupId = "T002"
                });

            modelBuilder.Entity<Group>().HasData(
                new Group()
                {
                    GroupId = "T001",
                    GroupName = "管理者"
                },
                new Group()
                {
                    GroupId = "T002",
                    GroupName = "聯徵發查"
                });

            modelBuilder.Entity<MenuCode>().HasData(
                new MenuCode
                {
                    FunctionSeq = 1,
                    MainFuncionName = "Test",
                    DetailFunctionName = "Index1",
                    GroupId = "T001"
                },
                new MenuCode
                {
                    FunctionSeq = 2,
                    MainFuncionName = "Test",
                    DetailFunctionName = "Index1",
                    GroupId = "T002"
                },
                new MenuCode
                {
                    FunctionSeq = 3,
                    MainFuncionName = "Test",
                    DetailFunctionName = "Index2",
                    GroupId = "T001"
                },
                new MenuCode
                {
                    FunctionSeq = 4,
                    MainFuncionName = "TestApi",
                    DetailFunctionName = "Index1",
                    GroupId = "T001"
                });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<MenuCode> MenuCodes { get; set; }


    }
}
