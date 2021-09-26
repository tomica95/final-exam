using Application.DTO;
using Application.DTO.Pagination;
using Application.DTO.Search;
using Application.Queries.Room;
using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Room
{
	public class EFGetAllRoomsQuery : IGetAllRooms
	{
		private readonly Context _context;
		private readonly IMapper _mapper;

		public EFGetAllRoomsQuery(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 4;

		public string Name => "Get Rooms";

		public PagedResponse<RoomDTO> Execute(SearchRoomDTO dto)
		{
			var rooms = _context.Rooms
				.Include(rt => rt.RoomType)
				.Include(p => p.Property)
				.AsQueryable();

			if (!string.IsNullOrEmpty(dto.Name) || !string.IsNullOrWhiteSpace(dto.Name))
			{
				rooms = rooms.Where(r => r.Name.ToLower().Contains(dto.Name.ToLower()));
			}

			var skipCount = dto.PerPage * (dto.Page - 1);

			var roles = _mapper.Map<List<RoomDTO>>(rooms.Skip(skipCount).Take(dto.PerPage).ToList());

			var reponse = new PagedResponse<RoomDTO>
			{
				CurrentPage = dto.Page,
				ItemsPerPage = dto.PerPage,
				TotalCount = rooms.Count(),
				Items = roles
			};

			return reponse;
		}
	}
}