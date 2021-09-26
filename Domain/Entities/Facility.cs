using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Facility : BaseEntity
	{
		public string Name { get; set; }


		public virtual ICollection<FacilityRoom> FacilityRooms { get; set; } = new HashSet<FacilityRoom>();

	}
}
