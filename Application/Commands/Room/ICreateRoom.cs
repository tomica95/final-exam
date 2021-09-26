using Application.CommandHendler;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Room
{
	public interface ICreateRoom : ICommand<RoomDTO>
	{
	}
}
