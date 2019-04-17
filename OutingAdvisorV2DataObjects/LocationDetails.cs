using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutingAdvisorV2DataObjects
{
    [Table("LocationDetails", Schema = "OutingAdvisorV2")]
    public class LocationDetails: IRowVersionIncrementer
    {
        public LocationDetails()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identity { get; set; }
        [Required]
        public int LocationID { get; set; }
        [Required]
        public int TypeID { get; set; }
        public string Season { get; set; }
        [ConcurrencyCheck]
        public int RowVersion { get; set; }

        [ForeignKey("TypeID")]
        public LocationTypeMaster LocationTypeMaster { get; set; }

        void IRowVersionIncrementer.OnSavingChanges()
        {
            if (RowVersion > 2147483647)
                RowVersion = 1;
            else
                RowVersion++;
        }
    }
}
