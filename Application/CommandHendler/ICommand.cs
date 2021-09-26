using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CommandHendler
{
	public interface ICommand<TRequest>
	{
		void Execute(TRequest request);
	}
}
