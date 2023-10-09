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
                    Id =Guid.Parse("48fbe5c5-1f55-4545-a360-6dd6a0414a4f") ,
                    Name = "Medium"
                 },
                  new Difficulty()
                  {
                    Id = Guid.Parse("149d4cfa-347f-46ee-abd3-e33f9197fd2e") ,
                    Name = "Hard"
                  }
            };
            //seed difficulties to the database

            modelBuilder.Entity<Difficulty>().HasData(Difficulties);

        }
    }

}
