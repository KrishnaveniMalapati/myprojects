using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region>Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                 new Difficulty()
                 {
                    Id = Guid.Parse("dd4c0950-fb61-4c20-8b5b-70592aafc614") ,
                    Name = "Easy"
                 },
                 new Difficulty()
                 {
                    Id = Guid.Parse("48fbe5c5-1f55-4545-a360-6dd6a0414a4f") ,
                    Name = "Medium"
                 },
                  new Difficulty()
                  {
                    Id = Guid.Parse("149d4cfa-347f-46ee-abd3-e33f9197fd2e") ,
                    Name = "Hard"
                  }
            };
            //seed difficulties to the database

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            // seed data for regions

            var regions = new List<Region>()
            {
                new Region() 
                {
                    Id = Guid.Parse("a6396964-9e21-45e5-a9d4-6ff284112164"),
                    Name = "Auckland",
                    Code = "AWL",
                    RegionImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.newzealand.com%2Fassets%2FTourism-NZ%2FAuckland%2F98618569ff%2Fimg-1536065871-6217-4403-p-10D1D0BD-B88E-AAB3-AE3F2E903EF65717-2544003__aWxvdmVrZWxseQo_CropResizeWzEyMDAsNjMwLDc1LCJqcGciXQ.jpg&tbnid=afMD--rWiAoJ1M&vet=12ahUKEwiA3NmT98KCAxWffWwGHWF3DWoQMygBegQIARBv..i&imgrefurl=https%3A%2F%2Fwww.newzealand.com%2Fin%2Fauckland%2F&docid=LplqmIiu5MkpZM&w=1200&h=630&q=auckland&ved=2ahUKEwiA3NmT98KCAxWffWwGHWF3DWoQMygBegQIARBv"
				},

				  new Region
				{
					Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
					Name = "Northland",
					Code = "NTL",
					RegionImageUrl = null
				},
				new Region
				{
					Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
					Name = "Bay Of Plenty",
					Code = "BOP",
					RegionImageUrl = null
				},
				new Region
				{
					Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
					Name = "Wellington",
					Code = "WGN",
					RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
				},
				new Region
				{
					Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
					Name = "Nelson",
					Code = "NSN",
					RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
				},
				new Region
				{
					Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
					Name = "Southland",
					Code = "STL",
					RegionImageUrl = null
				},
			};

            modelBuilder.Entity<Region>().HasData(regions);

        }
    }

}
