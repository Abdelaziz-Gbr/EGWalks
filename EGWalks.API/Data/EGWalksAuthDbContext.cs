using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EGWalks.API.Data
{
    public class EGWalksAuthDbContext : IdentityDbContext
    {
        public EGWalksAuthDbContext(DbContextOptions<EGWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "edb15d33-b0a0-420b-a5b9-026d3ee06689";
            var writerRoleId = "72f19fc5-b1d0-4ee1-b108-820e95d1fb22";

            var roles = new List<IdentityRole>() {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "reader",
                    NormalizedName = "reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "writer",
                    NormalizedName = "writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
