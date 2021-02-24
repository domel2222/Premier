using Premier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Premier.Context;

namespace Premier.DAL
{
    public class TournamentRepository : ITournamentRepository
    {

        private readonly TournamentContext _context;
        private readonly ILogger<TournamentRepository> _logger;

        public TournamentRepository(TournamentContext context, ILogger<TournamentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object {entity.GetType()} to the contrxt");
            _context.Add(entity);
            
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing and object {entity.GetType()} from the context");
            _context.Remove(entity);
        }


        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing and object {entity.GetType()} from the context");
            _context.Update(entity);
        }

        public async Task<Team[]> GetAllTeamsAsync()
        {
            _logger.LogInformation($"Getting all teams ");

            var query = _context.Teams.OrderBy(t => t.TeamName);

            return await query.ToArrayAsync();
        }

        public async Task<Tournament[]> GetAllTournamentAsync(bool includeMatches = false)
        {
            _logger.LogInformation($"Getting all Tournament");

            IQueryable<Tournament> query = _context.Tournaments
                .Include(l => l.Location);

            if(includeMatches)
            {
                query = query
                    .Include(m => m.Matches).ThenInclude(t => t.Team1)
                    .Include(m => m.Matches).ThenInclude(t => t.Team2);
            }

            query = query.OrderByDescending(d => d.StartEventDate);

            return await query.ToArrayAsync();
        } 

        public async Task<Tournament[]> GetAllTournamentByEventData(DateTime dateTime, bool includeMatches = false)
        {
            _logger.LogInformation($"Getting all Tournament");

            IQueryable<Tournament> query = _context.Tournaments
                .Include(t => t.Location);

            if (includeMatches)
            {
                query = query
                    .Include(m => m.Matches)
                    .ThenInclude(tm => tm.Team1)
                    .Include(m=> m.Matches)
                    .ThenInclude(tm => tm.Team2);
            }

            query = query.OrderByDescending(d => d.StartEventDate)
                .Where(d => d.StartEventDate == dateTime);

            return await query.ToArrayAsync();
        }

        public async Task<Match> GetMatchByNickNameAsync(string nickName, int matchId, bool includeMatches = false)
        {
            _logger.LogInformation($"Getting all matches in Tournament");

            IQueryable<Match> query = _context.Matches;

            if (includeMatches)
            {
                query = query.Include(t => t.Team1).Include(t => t.Team2);
            }

            query = query.Where(m => m.MatchId == matchId && m.Tournament.NickName == nickName);


            return await query.FirstOrDefaultAsync();
        }

        public async Task<Match[]> GetMatchesByNickNameAsync(string nickName, bool includeMatches = false)
        {
            _logger.LogInformation($"Getting all Matches in Tournament");

            IQueryable<Match> query = _context.Matches;

            if (includeMatches)
            {
                query = query.Include(m => m.Team1).Include(m => m.Team2);
            }

            query = query.Where(n => n.Tournament.NickName == nickName);

            return await query.ToArrayAsync();
        }

        public async Task<Team> GetTeamAsync(int teamId)
        {
            _logger.LogInformation($"Get team by Id");

            var query = _context.Teams.Where(t => t.TeamId == teamId);

            return await query.FirstOrDefaultAsync();
        }

        public async  Task<Team[]> GetTeamsByNickNameAsync(string nickName)
        {
            _logger.LogInformation($"Getting all Teams for Touranemnts");

            IQueryable<Team> query = (IQueryable<Team>)_context.Matches
                .Where(m => m.Tournament.NickName == nickName)
                .Select(m => new { Team1 = m.Team1.TeamName, Team2 = m.Team2.TeamName })
                .Distinct();

            return await query.ToArrayAsync();
        }

        public async Task<Tournament> GetTournamentAsync(string nickName, bool includeMatches = false)
        {
            _logger.LogInformation($"Getting a Tournamnet for {nickName}");

            IQueryable<Tournament> query = _context.Tournaments
                .Include(l => l.Location);

            if (includeMatches)
            {
                query = query
                    .Include(m => m.Matches).ThenInclude(t => t.Team1)
                    .Include(m => m.Matches).ThenInclude(t => t.Team2);
            }

            query = query.Where(n => n.NickName == nickName);

            return await query.FirstOrDefaultAsync();

        }

        public async Task<bool>  SaveChangesAsync()
        {
            _logger.LogInformation($"Attempting to save this changes");


            //return if something are change

            return (await _context.SaveChangesAsync() > 0);

        }


    }
}
