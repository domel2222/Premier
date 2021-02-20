using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Premier.Models;

namespace Premier.Context
{
    public class TournamentContext : DbContext
    {
        private readonly IConfiguration _config;
        public TournamentContext(DbContextOptions option, IConfiguration config) : base (option)
        {
            _config = config;
        }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Location> Locations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Tournament"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tournament>()
                .HasData(new
                {
                    TournamentId = 1,
                    Name = "Dinosaurus Cup",
                    NickName = "Tyro",
                    StartEventDate = new DateTime(2022, 01, 05),
                    LocationId = 1,
                    NumberOfTeam = 4

                });
            builder.Entity<Location>()
                .HasData(new
                {
                    LocationId = 1,
                    StadiumName = "Emirates Stadium",
                    Addres1 = "75 Drayton Park",
                    CityTown = "London",
                    Capacity = 60338,
                    Country = "England"

                });
            builder.Entity<Match>()
                .HasData(new
                {
                    MatChId = 1,
                    TournamentId = 1,
                    Team1Id = 1,
                    Team2Id = 2,
                    Result = "3:1"
                },
                new
                {
                    MatchId = 2,
                });
        }
    }
}
