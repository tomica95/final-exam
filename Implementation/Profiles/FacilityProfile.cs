using Application.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Profiles
{
	public class FacilityProfile : Profile
	{
		public FacilityProfile()
		{
			CreateMap<FacilityDTO, Facility>();
			CreateMap<Facility, FacilityDTO>()
				 .ForMember(dto => dto.Rooms,
					opt => opt.MapFrom(facility => facility.FacilityRooms.Select(fr => fr.Room).ToList()));
        }
	}
}
