using System;
using Microsoft.EntityFrameworkCore;
using OutingAdvisorV2DataObjects;

namespace OutingAdvisorV2DataLayer
{
    public class LocationContext: DbContext
    {
        public LocationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<Location> Location { get; set; }
        public DbSet<LocationActivitiesMapper> LocationActivitiesMapper { get; set; }
        public DbSet<LocationActivitiesMaster> LocationActivitiesMaster { get; set; }
        public DbSet<LocationDetails> LocationDetails { get; set; }
        public DbSet<LocationTypeMaster> LocationTypeMaster { get; set; }
    }
}
