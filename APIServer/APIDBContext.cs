using Microsoft.EntityFrameworkCore;
using APIServer.Model;

namespace APIServer
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions<APIDBContext> opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Data seeder

            modelBuilder.Entity<Company>().HasData(
              new Company
              {
                  ID = 1,
                  Name = "Company 1",
                  Address = "Minsk"
              }
            );

            modelBuilder.Entity<User>().HasData(
              new User
              {
                  ID = 1,
                  Email = "admin@test.com",
                  Password = "pass",
                  FirstName = "Admin",
                  LastName = "Admin",
                  Country = "BY"
              }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
