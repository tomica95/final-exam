using Application.DTO;
using Application.DTO.Pagination;
using Application.DTO.Search;
using Application.Queries.Property;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Property
{
	public class EFGetAllProperties : IGetAllProperties
	{
		private readonly Context _context;
		private readonly IMapper _mapper;

		public EFGetAllProperties(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 5;

		public string Name => "Get Properties";

		public PagedResponse<PropertyDTO> Execute(SearchPropertyDTO search)
		{
			var rolesQuery = _context.Properties.AsQueryable();

			if (!string.IsNullOrEmpty(search.Type) || !string.IsNullOrWhiteSpace(search.Type))
			{
				rolesQuery = rolesQuery.Where(r => r.Type.ToLower().Contains(search.Type.ToLower()));
			}

			var skipCount = search.PerPage * (search.Page - 1);

			var roles = _mapper.Map<List<PropertyDTO>>(rolesQuery.Skip(skipCount).Take(search.PerPage).ToList());

			var reponse = new PagedResponse<PropertyDTO>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = rolesQuery.Count(),
				Items = roles
			};

			return reponse;
		}
	}
}
