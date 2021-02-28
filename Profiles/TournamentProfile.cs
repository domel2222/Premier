﻿using AutoMapper;
using Premier.DTOS;
using Premier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Profiles
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            this.CreateMap<Tournament, TournamentDTO>()
                .ForMember(c => c.StadiumN, o => o.MapFrom(s => s.Location.StadiumName))
                .ForMember(c => c.Address, o => o.MapFrom(s => s.Location.Address1)).ReverseMap();

            this.CreateMap<Match, MatchDTO>()
                .ForMember(c => c.teamTeamName, o => o.MapFrom(s => s.Team1.TeamName))
                .ForMember(c => c.teamTeamName2, o => o.MapFrom(s => s.Team2.TeamName)).ReverseMap();
            //.ForMember(c => c.Team2, o => o.MapFrom(s => s.Team2.TeamName));

            this.CreateMap<Location, LocationDTO>().ReverseMap();
        }
    }
}
