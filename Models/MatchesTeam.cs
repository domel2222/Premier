using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Models
{
    public class MatchesTeam
    {
        public int  MainId { get; set; }
        public Match Match { get; set; }
        public Team Team { get; set; }
    }
}
