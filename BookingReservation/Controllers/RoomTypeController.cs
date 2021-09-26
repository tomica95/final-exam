using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CommandHendler;
using Application.Commands.RoomType;
using Application.DTO;
using Application.DTO.Search;
using Application.Queries.RoomType;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingReservation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomTypeController : ControllerBase
	{
		private readonly CommandExecutor executor;

		public RoomTypeController(CommandExecutor executor)
		{
			this.executor = executor;
		}

		// GET: api/<RoomTypeController>
		[HttpGet]
		public IActionResult Get([FromQuery] SearchRoomTypeDTO search, [FromServices] IGetAllRoomTypes query)
		{
			return Ok(executor.ExecuteQuery(query, search));
		}

		// GET api/<RoomTypeController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<RoomTypeController>
		[HttpPost]
		public IActionResult Post([FromBody] RoomTypeDTO dto, [FromServices] ICreateRoomType command)
		{
			executor.ExecuteCommand(command, dto);

			return NoContent();
		}

		// PUT api/<RoomTypeController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<RoomTypeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
