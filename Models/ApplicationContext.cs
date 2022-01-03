using Microsoft.EntityFrameworkCore;

namespace RocketApi.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Lead> leads { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Battery> batteries { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Column> columns { get; set; }
        public DbSet<Elevator> elevators { get; set; }

        public DbSet<Interventions> interventions { get; set; }
        public virtual DbSet<Quotes> quotes { get; set; }

        

    }
}
