using Application.Commands.Property;
using Application.DTO;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.PropertyCommand
{
	public class EFCreateProperty : BaseCommand, ICreateProperty
	{
		public EFCreateProperty(Context context, IMapper mapper) : base(context, mapper)
		{
		}

		public int Id => 5;
		public string Name => "Create Property Command";

		public void Execute(PropertyDTO request)
		{
			var property = Mapper.Map<Property>(request);

			Context.Properties.Add(property);
			Context.SaveChanges();
		}
	}
}
