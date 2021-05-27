using diukin_test.Models;
using Microsoft.EntityFrameworkCore;

namespace diukin_test.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
