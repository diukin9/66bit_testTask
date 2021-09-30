using Microsoft.EntityFrameworkCore;
using PlayerCatalog.Data.Models;

namespace PlayerCatalog.Data.PostgreSQL
{
    public class DataContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PlayerLocalization> PlayerLocalizations { get; set; }
        public DbSet<TeamLocalization> TeamLocalizations { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
