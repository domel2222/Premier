using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string StadiumName { get; set; }
        public string Address1 { get; set; }
        public string CityTown { get; set; }
        public int Capacity { get; set; }
        public string Country { get; set;  }
    }
}
