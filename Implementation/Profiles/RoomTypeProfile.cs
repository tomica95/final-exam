using Application.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
	public class RoomTypeProfile : Profile
	{
		public RoomTypeProfile()
		{
			CreateMap<RoomType, RoomTypeDTO>();
			CreateMap<RoomTypeDTO, RoomType>();
		}

	}
}
