using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CommandHendler
{
	public class CommandExecutor
	{
       
        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            command.Execute(request);
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            return query.Execute(search);
        }
    }
}
