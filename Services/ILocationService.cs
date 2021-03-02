using Premier.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Services
{
    public interface ILocationService
    {
        Task<LocationDTO[]> AllLocations();
    }
}
