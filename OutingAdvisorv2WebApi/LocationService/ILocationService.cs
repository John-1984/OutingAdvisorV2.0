using System.Collections.Generic;
using DO = OutingAdvisorV2DataObjects;
namespace OutingAdvisorv2WebApi.LocationService
{
    public interface ILocationService
    {
        DO.Location Get(string name);
        List<DO.Location> GetAll();
        bool Update(DO.Location location);
        bool Delete(DO.Location location);
        bool Insert(DO.Location location);

    }
}
