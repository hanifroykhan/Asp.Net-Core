using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) { }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for difficulties 

            var difficulties = new List<Difficulty>()
            {
                new Difficulty ()
                {
                    Id = Guid.Parse("61bc18fd-e87f-4639-8afa-6e93ec0e5e8e"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("45fde8b6-8e73-4d66-8e26-506d3e14704b"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("57486005-9ed6-46d9-9a1b-05d25a1b9285"),
                    Name = "Hard"
                },
            };

            //seed difficulties to database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("baba13a3-e182-4bff-b22f-f8f5df88e4e3"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("e26aa732-9848-44e6-871b-b38622526ca7"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("1fd29e6a-7ca9-40b6-9f5c-0acc9f1ea36f"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("0cba8978-715b-4903-ba58-a7a46f57fed8"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("931b25f3-b052-423b-93d7-f42094d29304"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("46a4cd1c-af67-42cf-9555-63758fbff76d"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },

            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }


}
  