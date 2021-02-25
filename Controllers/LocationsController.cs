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
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace Premier.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationrepo;
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;

        public LocationsController(ILocationRepository locationrepo, IMapper mapper)
        {
            this._locationrepo = locationrepo;
            this._mapper = mapper;
            //this._logger = logger;
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

        [HttpGet("{locationid:int}")]

        public async Task<ActionResult<LocationDTO>> GetOneLocationById(int locationId)
        {
            try
            {
                var result = await _locationrepo.GetLocationById(locationId);

                if (result == null) return NotFound();

                return _mapper.Map<LocationDTO>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
            return BadRequest();
        }

        [HttpPatch("{locationid:int}")]
        public async Task<ActionResult<LocationDTO>> PatchLocation(int locationid, [FromBody]JsonPatchDocument<LocationDTO> patchDoc)
        {
            if (patchDoc == null)
            {
                //_logger.LogInformation($"Client doesn't send object");
                return NotFound();
            }

            var location = await _locationrepo.GetLocationById(locationid);

            if (location == null)
            {
                return NotFound();
            }
            else
            {
                var locationPath = _mapper.Map<LocationDTO>(location);
                patchDoc.ApplyTo(locationPath, ModelState);
                _mapper.Map(locationPath, location);
                await _locationrepo.SaveChangesAsync();

                return NoContent();
            }



        }


    }
}
