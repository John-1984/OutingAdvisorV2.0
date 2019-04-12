using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutingAdvisorV2DataObjects
{
    [Table("LocationTypeMaster", Schema = "OutingAdvisorV2")]
    public class LocationTypeMaster : IRowVersionIncrementer
    {
        public LocationTypeMaster()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identity { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [ConcurrencyCheck]
        public long RowVersion { get; set; }

        void IRowVersionIncrementer.OnSavingChanges()
        {
            RowVersion ++;
        }
    }
}
