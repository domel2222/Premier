using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Premier.DAL;
using Premier.Models;
using Premier.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Controllers
{
    [ApiController]
    [Route("api/tournaments/{nickname}/matches")]
    public class MatchesController : ControllerBase
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public MatchesController(ITournamentRepository tournamentRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this._tournamentRepository = tournamentRepository;
            this._mapper = mapper;
            this._linkGenerator = linkGenerator;
        }
        [HttpGet]
        public async Task <ActionResult<MatchDTO[]>> GetMatches(string nickname)
        {
            try
            {
                var yesnt = true;
                var matches = await _tournamentRepository.GetMatchesByNickNameAsync(nickname, yesnt);

                //return Ok(matches);
                return _mapper.Map<MatchDTO[]>(matches);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed tp get matches");
            }
        }
        [HttpGet("{matchId:int}")]
        public async Task <ActionResult<MatchDTO>> GetMatchInTournament(string nickname, int matchId)
        {
            try
            {

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get matches");
            }
        }
    }
}
