using Premier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.DAL
{
    public interface ILocationRepository
    {


        Task<bool> SaveChangesAsync();

        //Location 
        Task<Location[]> GetAllLocation();

        Task<Location> GetLocationById(int locationId);

    }
}
