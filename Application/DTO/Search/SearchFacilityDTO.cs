using Application.DTO.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Search
{
	public class SearchFacilityDTO : PagedSearch
	{
		public string Name { get; set; }
		public string Room { get; set; }

	}
}
