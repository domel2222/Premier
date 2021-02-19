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

        public TournamentContext(DbContextOptions option) : base (option)
        {

        }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
