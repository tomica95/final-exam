using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class FacilityRoom
	{
		public int FacilityId { get; set; }
		public int RoomId { get; set; }


		public virtual Facility Facility { get; set; }
		public virtual Room Room { get; set; }

	}
}
