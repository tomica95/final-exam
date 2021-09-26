using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
	public class RoomDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double Space { get; set; }

		public RoomTypeDTO RoomType { get; set; }  
		public PropertyDTO Property { get; set; }
	}
}
