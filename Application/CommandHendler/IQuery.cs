using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CommandHendler
{
	public interface IQuery<TSearch, TResult>
	{
		TResult Execute(TSearch search);
	}
}
