using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Property : BaseEntity
	{
		public string Type { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Country { get; set; }

		//	Property has many Rooms
		public virtual ICollection<Room> Rooms { get; set; }


	}
}
