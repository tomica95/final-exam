using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
	public class EntityNotFoundException : Exception
	{
		public EntityNotFoundException(int Id) :base($"Entity with an id: {Id} doesn't exist.")
		{

		}
	}
}
