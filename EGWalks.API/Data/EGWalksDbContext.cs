using EGWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EGWalks.API.Data
{
    public class EGWalksDbContext : DbContext
    {
        public EGWalksDbContext(DbContextOptions<EGWalksDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var difs = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id = Guid.Parse("d23b6401-144d-4350-b6ff-8225e05dfea7"),
                    Level = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("49f69dc5-b326-440f-ac88-baecc5d18cb2"),
                    Level = "Mid"
                },
                new Difficulty
                {
                    Id = Guid.Parse("3d7a44c7-ee8e-42db-9d92-0e47e8e9f0cd"),
                    Level = "Hard"
                }
            };
            // seeding Difficulty
            modelBuilder.Entity<Difficulty>().HasData(difs);

            var regions = new List<Region>()
            {
                new Region 
                {
                    Id = Guid.Parse("69733ddb-7720-4bee-8159-33639e6663c1"),
                    Code = "NYC",
                    Name = "New York",
                    RegionImageUrl = "drugs&shit.org"
                }
            };
            // seefing regions
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
