using Microsoft.EntityFrameworkCore;

namespace CorsaRacing.Models
{
    public class Context : DbContext
    {
        public DbSet<User> Drivers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<ParticipationRace> ParticipationRace { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
