using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutingAdvisorV2DataObjects
{
    public class LocationPointers
    {
        public LocationPointers()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identity { get; set; }
        [Required]
        public int LocationID { get; set; }
        [Required]
        public string Pointer { get; set; }
    }
}
