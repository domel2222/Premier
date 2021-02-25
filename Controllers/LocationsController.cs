using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Premier.DAL;
using Premier.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Premier.DTOS;

namespace Premier.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationrepo;
        private readonly IMapper _mapper;

        public LocationsController(ILocationRepository locationrepo, IMapper mapper)
        {
            this._locationrepo = locationrepo;
            this._mapper = mapper;
        }
        

        [HttpGet]
        [Produces("application/json")]

        public async Task<ActionResult<LocationDTO[]>> GetLocations()
        {
            try
            {
                var result = await _locationrepo.GetAllLocation();

                //return this.Ok(result);

                return _mapper.Map<LocationDTO[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database fail");
            }
            
        }
    }
}
