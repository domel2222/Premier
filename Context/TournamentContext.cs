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
        public DbSet
    }
}
