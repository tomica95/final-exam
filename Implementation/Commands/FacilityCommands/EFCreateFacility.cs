using Application.Commands.Facility;
using Application.DTO;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.FacilityCommands
{
	public class EFCreateFacility : BaseCommand, ICreateFacility
	{
		public EFCreateFacility(Context context, IMapper mapper) : base(context, mapper)
		{
		}

		public int Id => 7;
		public string Name => "Create Facility Command";

		public void Execute(FacilityDTO dto)
		{
			var facility = Mapper.Map<Facility>(dto);

			Context.Facilities.Add(facility);

			foreach (var item in dto.Rooms)
			{
				facility.FacilityRooms.Add(new FacilityRoom
				{
					FacilityId = facility.Id,
					RoomId = item.Id
				});
			}

			Context.SaveChanges();
		}
	}
}
