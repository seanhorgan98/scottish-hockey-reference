using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
    }
}
