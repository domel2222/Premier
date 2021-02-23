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
        public TournamentContext(DbContextOptions option, IConfiguration config) : base(option)
        {
            _config = config;
        }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Location> Locations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Tournament"), builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tournament>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Tournament>()
                .HasData(new
                {
                    TournamentId = 1,
                    Name = "Dinosaur Cup",
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
                    Address1 = "75 Drayton Park",
                    CityTown = "London",
                    Capacity = 60338,
                    Country = "England"

                });
            builder.Entity<Match>()
                .HasData(new
                {
                    MatchId = 1,
                    TournamentId = 1,
                    Team1TeamId = 1,
                    Team2TeamId = 2,
                    Result = "3:1"
                },
                new
                {
                    MatchId = 2,
                    TournamentId = 1,
                    Team1TeamId = 3,
                    Team2TeamId = 4,
                    Result = "3:2"
                });
            builder.Entity<Team>()
                .HasData(new
                {
                    TeamId = 1,
                    TeamName = "Arsenal",
                    City = "London",
                    Country = "England"
                },
                new
                {
                    TeamId = 2,
                    TeamName = "Chelsea",
                    City = "London",
                    Country = "England"
                },
                new
                {
                    TeamId = 3,
                    TeamName = "Sporting",
                    City = "Lisbona",
                    Country = "Portugal"
                },
                new
                {
                    TeamId = 4,
                    TeamName = "Real",
                    City = "Madrid",
                    Country = "Spain"
                });
        }
    }
}
