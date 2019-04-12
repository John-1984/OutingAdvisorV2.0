using System;
namespace OutingAdvisorV2DataObjects
{
    public class LocationDetails
    {
        public LocationDetails()
        {
        }

        public int Identity { get; set; }
        public int LocationID { get; set; }
        public int TypeID { get; set; }
        public string Season { get; set; }
    }
}
