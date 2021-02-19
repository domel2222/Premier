using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public Tournament Tournament { get; set; }

        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public string Result { get; set; }
    }
}
