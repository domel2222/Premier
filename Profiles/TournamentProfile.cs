using AutoMapper;
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
                .ForMember(c => c.Address, o => o.MapFrom(s=>s.Location.Address1));
        }
    }
}
