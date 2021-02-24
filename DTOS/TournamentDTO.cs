﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.DTOS
{
    public class TournamentDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string NickName { get; set; }
        public DateTime StartEventDate { get; set; } = DateTime.MinValue;
        [Range(2, 100)]
        public int NumberOfTeam { get; set; } = 2;
        public string StadiumN { get; set; }
        public string Address { get; set; }
        public string LocationCityTown { get; set; }
        public int LocationCapacity { get; set; }
        public string LocationCountry { get; set; }

        public ICollection<MatchDTO> Matches { get; set; }
    }
}
