using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutingAdvisorV2DataObjects
{
    [Table("Location", Schema = "OutingAdvisorV2")]
    public class Location: IRowVersionIncrementer
    {
        public Location()
        {
            LocationActivitiesMapper = new HashSet<LocationActivitiesMapper>();
            LocationPointers = new HashSet<LocationPointers>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identity { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Approved { get; set; }
        [ConcurrencyCheck]
        public int RowVersion { get; set; }

        public ICollection<LocationActivitiesMapper> LocationActivitiesMapper { get; set; }
        public ICollection<LocationPointers> LocationPointers { get; set; }
        public LocationDetails LocationDetails { get; set; }

        void IRowVersionIncrementer.OnSavingChanges()
        {
            if (RowVersion > 2147483647)
                RowVersion = 1;
            else
                RowVersion++;
        }
    }
}
