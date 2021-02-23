using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Premier.DAL;
using Premier.DTOS;
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
        private readonly IMapper _mapper;

        public TournamentsController(ITournamentRepository tournamentRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [Produces("application/json")]
        //public async Task<IActionResult>  GetTournaments()
        public async Task<ActionResult<TournamentDTO[]>> GetTournaments()
        {
            try
            {
                var yesnt = true;
                var result = await _tournamentRepository.GetAllTournamentAsync();

                //TournamentDTO[] models = _mapper.Map<TournamentDTO[]>(result);

                //return this.Ok(result);
                return _mapper.Map<TournamentDTO[]>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");

            }



        }
        [HttpGet("{nickname}")]
        public async Task<ActionResult<TournamentDTO>> GetOneTournament(string nickname)
        {
            try
            {
                var result = await _tournamentRepository.GetTournamentAsync(nickname);

                if (result == null) return NotFound();

                return _mapper.Map<TournamentDTO>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure");
            }
        }
    }
}
