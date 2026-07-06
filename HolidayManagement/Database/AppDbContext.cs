using HolidayManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace HolidayManagement.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuration.GetConnectionString("Database");

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Center> Centers { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInstitution> userInstitutions { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
    }
}
