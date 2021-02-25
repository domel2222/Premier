using Premier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.DAL
{
    public class LocationRepository : ILocationRepository
    {
        public Task<Location[]> GetAllLocation()
        {
            throw new NotImplementedException();
        }

        public Task<Location> GetLocationById(int locationId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
