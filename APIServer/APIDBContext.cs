using Microsoft.EntityFrameworkCore;
using APIServer.Model;

namespace APIServer
{
    public class APIDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=APIDB;Integrated Security=True");
        }
    }
}
