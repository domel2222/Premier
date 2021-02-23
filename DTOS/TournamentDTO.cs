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
        public string StadiumN { get; set; }
        public string Address { get; set; }
        public string LocationCityTown { get; set; }
        public int LocationCapacity { get; set; }
        public string LocationCountry { get; set; }
    }
}
