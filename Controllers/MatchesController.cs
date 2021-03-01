﻿using AutoMapper;
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
    [ApiVersion("1.1")]
    [ApiVersion("1.0")]
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
                
                var matches = await _tournamentRepository.GetMatchesByNickNameAsync(nickname);

                //return Ok(matches);
                return _mapper.Map<MatchDTO[]>(matches);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed tp get matches");
            }
        }
        [HttpGet("{matchId:int}")]
        public async Task<ActionResult<MatchDTO>> GetMatchInTournament(string nickname, int matchId)
        {
            try
            {
                var match = await _tournamentRepository.GetMatchByNickNameAsync(nickname, matchId);
                if (match == null) return NotFound("Match dose not exist");
                return _mapper.Map<MatchDTO>(match);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get matches");
            }
        }
        [HttpPost]
        public async Task<ActionResult<MatchDTO>> AddNewMatch(string nickname, MatchDTO matchModel)
        //public async Task<ActionResult<MatchDTO>> AddNewMatch(string nickname, Match matchModel)
        {
            try
            {
                var tournament = await _tournamentRepository.GetTournamentAsync(nickname);
                if (tournament == null) return BadRequest("Tournament does not exist");
                // match from matchModel extract team name and get from database team by name , moreover assign Id to match id team??
                var match = _mapper.Map<Match>(matchModel);

                match.Tournament = tournament;

                _tournamentRepository.Add(match);

                if (await _tournamentRepository.SaveChangesAsync())
                {
                    var url = _linkGenerator.GetPathByAction(HttpContext, "GetMatchInTournament",
                        values: new { nickname, matchId = match.MatchId });

                    return Created(url, _mapper.Map<MatchDTO>(match));
                }
                else
                {
                    return BadRequest("Failed to save new match");
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add dadabase");
            }
        }

        [HttpPut("{matchId:int}")]
        public async  Task <ActionResult<MatchDTO>> UpdateMatch(string nickname, int matchId, MatchDTO matchModel)
        {
            try
            {
                var match = await _tournamentRepository.GetMatchByNickNameAsync(nickname, matchId);
                if (match == null) return NotFound("Couldn't find the talk");

                _mapper.Map(matchModel, match);

                if(matchModel.teamTeamName != null && matchModel.teamTeamName2 !=null)
                {
                    var teamid1 = 1;
                    var teamId2 = 2;
                    var team1 = await _tournamentRepository.GetTeamAsync(teamid1);
                    var team2 = await _tournamentRepository.GetTeamAsync(teamId2);
                    if(team1 != null)
                    {
                        match.Team1 = team1;
                    }
                }

                if(await _tournamentRepository.SaveChangesAsync())
                {
                    return _mapper.Map<MatchDTO>(match);
                }
                else
                {
                    return BadRequest("Failed update match in database");
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get match");
            }
        }
        [HttpDelete("{matchId:int}")]
        public async Task<IActionResult>  DeleteMatch(string nickname, int matchId)
        {
            try
            {
                var match = await _tournamentRepository.GetMatchByNickNameAsync(nickname, matchId);
                if (match == null) return NotFound("Failed to find the match");
                _tournamentRepository.Delete(match);

                if (await _tournamentRepository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Fail to delete");
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to Delete");
            }
        }
    }
}
