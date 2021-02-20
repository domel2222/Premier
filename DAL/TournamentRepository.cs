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

        public Task<Match[]> GetAllTeamsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tournament[]> GetAllTournamentAsync(bool includeMatches = false)
        {
            throw new NotImplementedException();
        }

        public Task<Tournament[]> GetAllTournamentByEventData(DateTime dateTime, bool includeMatches = false)
        {
            throw new NotImplementedException();
        }

        public Task<Match> GetMatchByNickNameAsync(string nickName, int matchId, bool includeMatches = false)
        {
            throw new NotImplementedException();
        }

        public Task<Match[]> GetMatchesByNickNameAsunc(string nickName, bool includeMatches = false)
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetTeamAsync(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<Team[]> GetTeamsByNickNameAsync(string nickName)
        {
            throw new NotImplementedException();
        }

        public Task<Tournament> GetTournamentAsync(string nickName, bool includeMatche = false)
        {
            throw new NotImplementedException();
        }

        public async Task<bool>  SaveChangesAsync()
        {
            _logger.LogInformation($"Attempting to save this changes");


            //return if something are change

            return (await _context.SaveChangesAsync() > 0);

        }
    }
}
