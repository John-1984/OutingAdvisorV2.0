using System;
using Microsoft.EntityFrameworkCore;
using DO = OutingAdvisorV2DataObjects;

namespace OutingAdvisorV2DataLayer.Location
{
    public class LocationContext: DbContext
    {
        public LocationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;port=3306;database=OutingAdvisorV2;uid=root;password=password;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<DO.Location> Location { get; set; }
        public DbSet<DO.LocationActivitiesMapper> LocationActivitiesMapper { get; set; }
        public DbSet<DO.LocationActivitiesMaster> LocationActivitiesMaster { get; set; }
        public DbSet<DO.LocationDetails> LocationDetails { get; set; }
        public DbSet<DO.LocationTypeMaster> LocationTypeMaster { get; set; }
    }
}
