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
        void Update<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //public interface IBaseRepository<T> where T : class
        
        //{
        //    Task<T[]> GetAll();
        //    Task<T> GetById(Guid id);
        //    void Add(T t);
        //    Task<T> Update(T t);
        //    void Remove(T entity);
        //    Task<bool> Commit();
        //}

        //Tournament

        Task<Tournament[]> GetAllTournamentAsync(bool includeMatches = false);
        Task<Tournament> GetTournamentAsync(string nickName, bool includeMatche = false);
        Task<Tournament[]> GetAllTournamentByEventData(DateTime dateTime, bool includeMatches = false);

        //Maches
        Task<Match> GetMatchByNickNameAsync(string nickName, int matchId);
        Task<Match[]> GetMatchesByNickNameAsync(string nickName);


        //Teams

        Task<Team[]> GetTeamsByNickNameAsync(string nickName);
        Task<Team> GetTeamAsync(int teamId);
        Task<Team[]> GetAllTeamsAsync();
    }
}
