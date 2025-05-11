using Microsoft.EntityFrameworkCore;
using Simulation_Communication.Model;

namespace Simulation_Communication.DB
{
    public class MyDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Menu> Menus { get; set; }
       
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
       
    }
}
