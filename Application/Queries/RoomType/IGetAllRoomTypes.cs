using Application.CommandHendler;
using Application.DTO;
using Application.DTO.Pagination;
using Application.DTO.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.RoomType
{
	public interface IGetAllRoomTypes : IQuery<SearchRoomTypeDTO, PagedResponse<RoomTypeDTO>>
	{
	}
}
