using ImmobileApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImmobileApp.Infrastructure
{
    public class ImmobileAppDbContext:DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ImmobileEntity> Immobiles { get; set; }
        public DbSet<ImageEnitty> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseNpgsql(@"Host=localhost:5432;Username=docker;Password=docker;Database=immobileAppDB");
    }
}
