using Application.Commands.RoomType;
using Application.DTO;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.RoomTypeCommands
{
	public class EFCreateRoomType : BaseCommand, ICreateRoomType
	{
		public EFCreateRoomType(Context context, IMapper mapper) :base(context, mapper)
		{
		}

		public int Id => 1;
		public string Name => "Create Room Type Command";

		public void Execute(RoomTypeDTO request)
		{
			var roomType = Mapper.Map<RoomType>(request);

			Context.RoomTypes.Add(roomType);
			Context.SaveChanges();

		}
	}
}
