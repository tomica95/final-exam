using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Room : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public double Space { get; set; }

		// Room has one RoomType
		public int RoomTypeId { get; set; }
		public virtual RoomType RoomType { get; set; }	

		// Room has one RoomType
		public int PropertyId { get; set; }
		public virtual Property Property{ get; set; }

		public virtual ICollection<FacilityRoom> RoomFacilities { get; set; } = new HashSet<FacilityRoom>();

	}
}
