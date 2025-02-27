using ImmobileApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImmobileApp.Infrastructure
{
    public class ImmobileAppDbContext:DbContext
    {


        public ImmobileAppDbContext(DbContextOptions<ImmobileAppDbContext> options) : base(options) { }
        
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ImmobileEntity> Immobiles { get; set; }
        public DbSet<ImageEnitty> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasMany(e => e.Immobiles)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserCreationId)
                .HasPrincipalKey(e => e.Id).IsRequired();

            modelBuilder.Entity<ImmobileEntity>()
                .HasMany(e => e.Images)
                .WithOne(e => e.Immobile)
                .HasForeignKey(e => e.ImmobileId)
                .HasPrincipalKey(e => e.Id).IsRequired();
        }
    }
}
