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

    }
}
