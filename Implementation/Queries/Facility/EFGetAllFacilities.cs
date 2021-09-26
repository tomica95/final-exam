using Application.DTO;
using Application.DTO.Pagination;
using Application.DTO.Search;
using Application.Queries.Facility;
using AutoMapper;
using DataAccess;
using Implementation.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Facility
{
	public class EFGetAllFacilities : BaseCommand, IGetAllFacilities
	{
		public EFGetAllFacilities(Context context, IMapper mapper) : base(context, mapper)
		{
		}

		public PagedResponse<FacilityDTO> Execute(SearchFacilityDTO dto)
		{
            var facilitiesQuery = Context.Facilities
                .Include("FacilityRooms.Room.RoomType")
                .Include("FacilityRooms.Room.Property")
                .AsQueryable();

            if (!string.IsNullOrEmpty(dto.Name) || !string.IsNullOrWhiteSpace(dto.Name))
            {
                facilitiesQuery = Context.Facilities.Where(p => p.Name.ToLower().Contains(dto.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(dto.Room) || !string.IsNullOrWhiteSpace(dto.Room))
            {
                facilitiesQuery = Context.Facilities.
                    Where(p => p.FacilityRooms.
                    Select(pu => pu.Room.Name.ToLower())
                    .Contains(dto.Room.ToLower()));
            }

            var proba = facilitiesQuery.ToList();

            var skipCount = dto.PerPage * (dto.Page - 1);

            var facilities = Mapper.Map<List<FacilityDTO>>(facilitiesQuery.Skip(skipCount).Take(dto.PerPage).ToList());

            var response = new PagedResponse<FacilityDTO>
            {
                CurrentPage = dto.Page,
                ItemsPerPage = dto.PerPage,
                TotalCount = facilitiesQuery.Count(),
                Items = facilities
            };

            return response;
        }
	}
}
