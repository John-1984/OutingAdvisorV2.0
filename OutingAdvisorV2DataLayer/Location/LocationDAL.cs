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
            context.Database.OpenConnection();
            context.Database.CloseConnection();
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
                    var test = context.Location;
                    var test1 = test.AsQueryable().ToString();
                    _result = context.Location
                                    //.Where(p => p.Approved == true)
                                    //.Include(p => p.LocationDetails)
                                    //    .ThenInclude(t => t.LocationTypeMaster)
                                    //.Include(p => p.LocationActivitiesMapper)
                                    .ToList();
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
