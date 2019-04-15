using System;
using System.Collections.Generic;
using DO = OutingAdvisorV2DataObjects;
namespace OutingAdvisorV2DataLayer.Location
{
    public interface ILocation
    {
        DO.Location Get(string name);
        List<DO.Location> GetAll();
        bool Update(DO.Location location);
        bool Delete(DO.Location location);
        bool Insert(DO.Location location);
    }
}
