using Application.DTO.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Search
{
	public class SearchPropertyDTO : PagedSearch
	{
		public string Type { get; set; }
	}
}
