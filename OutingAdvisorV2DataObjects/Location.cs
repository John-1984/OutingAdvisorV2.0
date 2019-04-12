using System;
namespace OutingAdvisorV2DataObjects
{
    public class Location
    {
        public Location()
        {
        }

        public int Identity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Approved { get; set; }
    }
}
