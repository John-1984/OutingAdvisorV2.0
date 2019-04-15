using System;
using System.Collections.Generic;
using DO =OutingAdvisorV2DataObjects;
using DAL = OutingAdvisorV2DataLayer.Location;

namespace OutingAdvisorv2WebApi.LocationService
{
    public class LocationService: ILocationService
    {
        private DAL.ILocation _locationDAL = null;
        public LocationService(DAL.ILocation locationDAL)
        {
            _locationDAL = locationDAL;
        }

        bool ILocationService.Delete(DO.Location location)
        {
            return _locationDAL.Delete(location);
        }

        DO.Location ILocationService.Get(string name)
        {
            return _locationDAL.Get(name);
        }

        List<DO.Location> ILocationService.GetAll()
        {
            return _locationDAL.GetAll();
        }

        bool ILocationService.Insert(DO.Location location)
        {
            return _locationDAL.Insert(location);
        }

        bool ILocationService.Update(DO.Location location)
        {
            return _locationDAL.Update(location);
        }
    }
}
