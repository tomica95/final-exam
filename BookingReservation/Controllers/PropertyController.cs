using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CommandHendler;
using Application.Commands.Property;
using Application.DTO;
using Application.DTO.Search;
using Application.Queries.Property;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingReservation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PropertyController : ControllerBase
	{
		private readonly CommandExecutor executor;

		public PropertyController(CommandExecutor executor)
		{
			this.executor = executor;
		}

		// GET: api/<PropertyController>
		[HttpGet]
		public IActionResult Get([FromQuery] SearchPropertyDTO search, [FromServices] IGetAllProperties query)
		{
			return Ok(executor.ExecuteQuery(query, search));
		}

		// GET api/<PropertyController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<PropertyController>
		[HttpPost]
		public IActionResult Post([FromBody] PropertyDTO dto, [FromServices] ICreateProperty command)
		{
			executor.ExecuteCommand(command, dto);

			return NoContent();
		}

		// PUT api/<PropertyController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<PropertyController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
