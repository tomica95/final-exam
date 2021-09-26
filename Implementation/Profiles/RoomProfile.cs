using Application.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
	public class RoomProfile : Profile
	{
		public RoomProfile()
		{
			CreateMap<Room, RoomDTO>();
			CreateMap<RoomDTO, Room>();
		}
	}
}
