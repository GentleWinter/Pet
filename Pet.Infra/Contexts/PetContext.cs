using Microsoft.EntityFrameworkCore;
using Pet.Domain.Entities;

namespace Pet.Infra.Contexts
{
    public class PetContext : DbContext
    {
        public DbSet<PetEntity> Pet { get; set; }

        public PetContext(DbContextOptions<PetContext> options)
             : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableDetailedErrors();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
