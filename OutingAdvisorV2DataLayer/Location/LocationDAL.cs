using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DO = OutingAdvisorV2DataObjects;

namespace OutingAdvisorV2DataLayer.Location
{
    public class LocationDAL : ILocation
    {
        public LocationDAL() {
            var context = new LocationContext();
        }

        bool ILocation.Delete(DO.Location location)
        {
            var _success = true;
            using (var context = new LocationContext())
            {
                try
                {
                    context.Location.Remove(location);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    _success = false;
                    Console.WriteLine(ex.Message);
                }
            }

            return _success;
        }

        DO.Location ILocation.Get(string name)
        {
            DO.Location _result = null;
            using (var context = new LocationContext())
            {
                try
                {
                    _result = context.Location
                                .Where(p => p.Approved == true && p.Name.ToLower().Equals(name.ToLower()))
                                .Include(p => p.LocationDetails)
                                    .ThenInclude(t => t.LocationTypeMaster)
                                .Include(p => p.LocationActivitiesMapper)
                                .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    //Log Exception
                    Console.WriteLine(ex.Message);
                }
            }

            return _result;
        }

        List<DO.Location> ILocation.GetAll()
        {
            List<DO.Location> _result = null;
            using (var context = new LocationContext())
            {
                try
                {
                    _result = context.Location
                                    .Where(p => p.Approved == true)
                                    .ToList();

                    IEnumerable<int> _locationIDs = _result.Select(s => s.Identity).ToList();
                    context.LocationDetails.Where(p => _locationIDs.Contains(p.LocationID)).Load();
                    context.LocationActivitiesMapper.Where(p => _locationIDs.Contains(p.LocationID)).Load();
                    context.LocationPointers.Where(p => _locationIDs.Contains(p.LocationID)).Load();

                    IEnumerable<int> _typeID = _result.Select(s => s.LocationDetails.TypeID).ToList();
                    IEnumerable<int> _activitiesID = context.LocationActivitiesMapper.Where(p => _locationIDs.Contains(p.LocationID)).Select(s => s.Identity).ToList();
                    context.LocationTypeMaster.Where(p => _typeID.Contains(p.Identity)).Load();
                    context.LocationActivitiesMaster.Where(p => _activitiesID.Contains(p.Identity)).Load();

                }
                catch (Exception ex)
                {
                    //Log Exception
                    Console.WriteLine(ex.Message);
                }
            }

            return _result;
        }

        bool ILocation.Insert(DO.Location location)
        {
            var _success = true;
            using (var context = new LocationContext())
            {
                try
                {
                    //Need to see if this insert adds duplicates to related foreignkey tables like locationtypemaster
                    //If so, then use context.entry mode to add location
                    context.Location.Add(location);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    _success = false;
                    Console.WriteLine(ex.Message);
                }
            }

            return _success;
        }

        bool ILocation.Update(DO.Location location)
        {
            var _success = true;
            using (var context = new LocationContext())
            {
                try
                {
                    context.Location.Update(location);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    _success = false;
                    Console.WriteLine(ex.Message);
                }
            }

            return _success;
        }
    }
}
