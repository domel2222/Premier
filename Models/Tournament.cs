using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Models
{
    public class Tournament
    {

        public int ToutnamentID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public Location Location { get; set; }
        public DateTime StartEventDate { get; set; } = DateTime.MinValue;
        public int NumberOfTeam { get; set; } = 2;
        public ICollection<Match> Matches {get; set;}
    }
}
