using Application.DTO.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Search
{
	public class SearchRoomDTO : PagedSearch
	{
		public string Name { get; set; }
	}
}
