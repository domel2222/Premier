using Microsoft.AspNetCore.Mvc;
using Premier.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentsController(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }


        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult>  GetTournaments()
        {
            try
            {
                var yesnt = true;
                var result = await _tournamentRepository.GetAllTournamentAsync();
                return this.Ok(result);

            }
            catch (Exception)
            {
                return BadRequest("Database Failure");
                
            }
            

            
        }
    }
}
