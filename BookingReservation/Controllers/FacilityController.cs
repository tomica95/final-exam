using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CommandHendler;
using Application.Commands.Facility;
using Application.Commands.Room;
using Application.DTO;
using Application.DTO.Search;
using Application.Queries.Facility;
using Application.Queries.Room;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingReservation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FacilityController : ControllerBase
	{
		private readonly CommandExecutor executor;

		public FacilityController(CommandExecutor executor)
		{
			this.executor = executor;
		}


		// GET: api/<FacilityController>
		[HttpGet]
		public IActionResult Get([FromQuery] SearchFacilityDTO search, [FromServices] IGetAllFacilities query)
		{
			return Ok(executor.ExecuteQuery(query, search));
		}

		// GET api/<FacilityController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<FacilityController>
		[HttpPost]
		public IActionResult Post([FromBody] FacilityDTO dto, [FromServices] ICreateFacility command)
		{
			executor.ExecuteCommand(command, dto);

			return NoContent();
		}

		// PUT api/<FacilityController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<FacilityController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
