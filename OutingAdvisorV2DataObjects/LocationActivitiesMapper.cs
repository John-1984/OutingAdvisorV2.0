using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutingAdvisorV2DataObjects
{
    [Table("LocationActivitiesMapper", Schema = "OutingAdvisorV2")]
    public class LocationActivitiesMapper
    {
        public LocationActivitiesMapper()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identity { get; set; }
        [Required]
        public int LocationID { get; set; }
        [Required]
        public int ActivityID { get; set; }
    }
}
