using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CommandHendler;
using Application.Commands.Room;
using Application.DTO;
using Application.DTO.Search;
using Application.Queries.Room;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingReservation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomController : ControllerBase
	{
		private readonly CommandExecutor executor;

		public RoomController(CommandExecutor executor)
		{
			this.executor = executor;
		}


		// GET: api/<RoomController>
		[HttpGet]
		public IActionResult Get([FromQuery] SearchRoomDTO search, [FromServices] IGetAllRooms query)
		{
			return Ok(executor.ExecuteQuery(query, search));
		}

		// GET api/<RoomController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<RoomController>
		[HttpPost]
		public IActionResult Post([FromBody] RoomDTO dto, [FromServices] ICreateRoom command)
		{
			executor.ExecuteCommand(command, dto);

			return NoContent();
		}

		// PUT api/<RoomController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<RoomController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
