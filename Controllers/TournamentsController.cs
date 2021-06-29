using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Premier.DAL;
using Premier.DTOS;
using Premier.Models;
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
        private readonly LinkGenerator _linkGenerator;

        public TournamentsController(ITournamentRepository tournamentRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }


        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<TournamentDTO[]>> GetTournaments(bool includesMatches = false)
        {
            //try
            //{
                //var yesnt = true;
                var result = await _tournamentRepository.GetAllTournamentAsync(includesMatches);

                

                //TournamentDTO[] models = _mapper.Map<TournamentDTO[]>(result);

                //return this.Ok(result);
                return _mapper.Map<TournamentDTO[]>(result);

            //}
            //catch (Exception)
            //{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");

            //}
        }

        [HttpGet("{nickname}")]
        //[HttpGet("{nickname:int}")]
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
        [HttpGet("search")]
        public async Task<ActionResult<TournamentDTO[]>> SearchByDate(DateTime date, bool includesMatches = false)
        {
            try
            {
                var result = await _tournamentRepository.GetAllTournamentByEventData(date, includesMatches);

                if (!result.Any()) return NotFound();

                return _mapper.Map<TournamentDTO[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpPost]
        public async Task<ActionResult<TournamentDTO>> RegisterNewTournament(TournamentDTO tour)
        {
            try
            {
                //if(ModelState.IsValid)
                var existingCup = await _tournamentRepository.GetTournamentAsync(tour.NickName);

                if (existingCup != null)
                {
                    return BadRequest("NickName is Use");
                }

                var location = _linkGenerator.GetPathByAction("GetOneTournament", "tournaments",
                    new { nickname = tour.NickName });

                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current nickname");
                }

                var tournament = _mapper.Map<Tournament>(tour);

                _tournamentRepository.Add(tournament);
                if (await _tournamentRepository.SaveChangesAsync())
                {
                    return Created($"/api/tournaments/{tournament.NickName}", _mapper.Map<TournamentDTO>(tournament));
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        [HttpPut ("{nickname}")]
        public async Task <ActionResult<TournamentDTO>> UpdateTournament(string nickname, TournamentDTO tour)
        {
            try
            {
                var oldTournament = await _tournamentRepository.GetTournamentAsync(nickname);
                if (oldTournament == null) return NotFound($"Could not found camp with nickname of {nickname}");


                _mapper.Map(tour, oldTournament);

                if(await _tournamentRepository.SaveChangesAsync())
                {
                    return _mapper.Map<TournamentDTO>(oldTournament);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }

        [HttpDelete("{nickname}")]
        public async Task <IActionResult> DeleteTournament(string nickname)
        {
            try
            {
                var deleteTournament = await _tournamentRepository.GetTournamentAsync(nickname);
                if (deleteTournament == null) return NotFound();

                _tournamentRepository.Delete(deleteTournament);

                if (await _tournamentRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        //[HttpPatch("{id}")]
        //public async Task<ActionResult<TournamentDTO>> PatchTournament(int id, JsonPatchDocument<TournamentDTO> patchDoc)
        //{
        //    var tour = _tournamentRepository.GetTournamentById(id);
        //    if(tour == null)
        //    {
        //        return NotFound();
        //    }

        //    var tourPatch = _mapper.

        //}
    }
}
