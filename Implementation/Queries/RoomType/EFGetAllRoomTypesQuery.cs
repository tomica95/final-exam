using Application.CommandHendler;
using Application.DTO;
using Application.DTO.Pagination;
using Application.DTO.Search;
using Application.Queries.RoomType;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.RoomType
{
	public class EFGetAllRoomTypesQuery : IGetAllRoomTypes
	{
		private readonly Context _context;
		private readonly IMapper _mapper;

		public EFGetAllRoomTypesQuery(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 2;

		public string Name => "Get Room Types";

		public PagedResponse<RoomTypeDTO> Execute(SearchRoomTypeDTO dto)
		{
			var rolesQuery = _context.RoomTypes.AsQueryable();

			if (!string.IsNullOrEmpty(dto.Name) || !string.IsNullOrWhiteSpace(dto.Name))
			{
				rolesQuery = rolesQuery.Where(r => r.Name.ToLower().Contains(dto.Name.ToLower()));
			}

			var skipCount = dto.PerPage * (dto.Page - 1);

			var roles = _mapper.Map<List<RoomTypeDTO>>(rolesQuery.Skip(skipCount).Take(dto.PerPage).ToList());

			var reponse = new PagedResponse<RoomTypeDTO>
			{
				CurrentPage = dto.Page,
				ItemsPerPage = dto.PerPage,
				TotalCount = rolesQuery.Count(),
				Items = roles
			};

			return reponse;
		}
	}
}
