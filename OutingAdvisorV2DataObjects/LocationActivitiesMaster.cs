using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutingAdvisorV2DataObjects
{
    [Table("LocationActivitiesMaster", Schema = "OutingAdvisorV2")]
    public class LocationActivitiesMaster: IRowVersionIncrementer
    {
        public LocationActivitiesMaster()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identity { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [ConcurrencyCheck]
        public int RowVersion { get; set; }

        void IRowVersionIncrementer.OnSavingChanges()
        {
            if (RowVersion > 2147483647)
                RowVersion = 1;
            else
                RowVersion++;
        }
    }
}
