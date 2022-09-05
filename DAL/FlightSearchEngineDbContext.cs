using DAL.EntityConfigurations;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class FlightSearchEngineDbContext : DbContext

    {
        public FlightSearchEngineDbContext()
        {
        }

        public FlightSearchEngineDbContext(DbContextOptions<FlightSearchEngineDbContext> options) : base(options)
        {

        }

        public DbSet<FlightSearchFilter> FlightSearchFilters { get; set; } = null!;
        public DbSet<FlightSearchResult> FlightSearchResults { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightSearchFilterConfiguration());
            modelBuilder.ApplyConfiguration(new FlightSearchResultConfiguration());
        }

    }
}