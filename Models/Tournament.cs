using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Models
{
    public class Tournament
    {
        [Key]
        public int TournamentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NickName { get; set; }
        public Location Location { get; set; }
        public DateTime StartEventDate { get; set; } = DateTime.MinValue;
        
        public int NumberOfTeam { get; set; } = 2;
        public ICollection<Match> Matches {get; set;}
    }
}
