using Premier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.DAL
{
    public interface ITournamentRepository
    {
        //general 

        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();


        //Tournament

        Task<Tournament[]> GetAllTournamentAsync(bool includeMatches = false);
        Task<Tournament> GetTournamentAsync(string nickName, bool includeMatche = false);
        Task<Tournament[]> GetAllTournamentByEventData(DateTime dateTime, bool includeMatches = false);

        //Maches
        Task<Match> GetMatchByNickNameAsync(string nickName, int matchId, bool includeMatches = false);
        Task<Match[]> GetMatchesByNickNameAsunc(string nickName, bool includeMatches = false);


        //Teams

        Task<Team[]> GetTeamsByNickNameAsync(string nickName);
        Task<Team> GetTeamAsync(int teamId);
        Task<Match[]> GetAllTeamsAsync();
    }
}
