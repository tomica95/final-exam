using Application.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
	public class PropertyProfile : Profile
	{
		public PropertyProfile()
		{
			CreateMap<Property, PropertyDTO>();
			CreateMap<PropertyDTO, Property>();
		}

	}
}
