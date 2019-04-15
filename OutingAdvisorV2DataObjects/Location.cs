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
        public long RowVersion { get; set; }

        public ICollection<LocationActivitiesMapper> LocationActivitiesMapper { get; set; }

        public LocationDetails LocationDetails { get; set; }

        void IRowVersionIncrementer.OnSavingChanges()
        {
            RowVersion ++;
        }
    }
}
