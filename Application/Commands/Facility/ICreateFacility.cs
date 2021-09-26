using Application.CommandHendler;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Facility
{
	public interface ICreateFacility : ICommand<FacilityDTO>
	{
	}
}
