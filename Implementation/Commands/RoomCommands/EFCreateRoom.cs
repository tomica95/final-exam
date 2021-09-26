using Application.Commands.Room;
using Application.DTO;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.RoomCommands
{
	public class EFCreateRoom : BaseCommand, ICreateRoom
	{
		public EFCreateRoom(Context context, IMapper mapper) : base(context, mapper)
		{
		}

		public int Id => 3;
		public string Name => "Create Room Command";				 

		public void Execute(RoomDTO request)
		{
			var room = Mapper.Map<Room>(request);

			room.RoomType = null;
			room.RoomTypeId = request.RoomType.Id;	

			room.Property = null;
			room.PropertyId = request.Property.Id;

			Context.Rooms.Add(room);
			Context.SaveChanges();
		}
	}
}
