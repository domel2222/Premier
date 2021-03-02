using AutoMapper;
using Microsoft.AspNetCore.Http;
using Premier.DAL;
using Premier.DTOS;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Services
{
    public class LocationServices : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationServices(ILocationRepository locationRepository, IMapper mapper)
        {
            this._locationRepository = locationRepository;
            this._mapper = mapper;
        }
        public async Task<LocationDTO[]> AllLocations()
        {
        
                var result = await _locationRepository.GetAllLocation();

                //return this.Ok(result);

                return _mapper.Map<LocationDTO[]>(result);

        }
    }
}
