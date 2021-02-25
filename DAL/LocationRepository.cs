using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Premier.Context;
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
        private readonly TournamentContext _context;
        private readonly ILogger _logger;

        public LocationRepository(TournamentContext context, ILogger logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public async Task<Location[]> GetAllLocation()
        {
            _logger.LogInformation($"Getting all location");

            var query = _context.Locations.OrderBy(l => l.LocationId);

            return await query.ToArrayAsync();
        }


        public async Task<Location> GetLocationById(int locationId)
        {
            _logger.LogInformation($"Getting location by {locationId}");

            var query = _context.Locations.Where(l => l.LocationId == locationId);

            return await query.FirstOrDefaultAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempting to save this change");

            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
