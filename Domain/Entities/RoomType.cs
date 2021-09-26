using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class RoomType : BaseEntity
	{
		public string Name { get; set; }

		//	RoomType has many Rooms
		public virtual ICollection<Room> Rooms { get; set; }
	}
}
