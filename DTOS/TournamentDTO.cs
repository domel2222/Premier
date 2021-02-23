using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.DTOS
{
    public class TournamentDTO
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public DateTime StartEventDate { get; set; } = DateTime.MinValue;
        public int NumberOfTeam { get; set; } = 2;
    }
}
