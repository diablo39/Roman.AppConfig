using Roman.CQRS.Abstraction.Command;
using Roman.CQRS.Abstraction.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.CQRS.Abstraction.CommandDecorators
{
    public class OperationTypeCommandHandlerDecorator<TIn, TOut> : ICommandHandler<TIn, TOut>
       where TIn : class, ICommand
    {
        private readonly ICommandHandler<TIn, TOut> _next;

        public OperationTypeCommandHandlerDecorator(ICommandHandler<TIn, TOut> next)
        {
            _next = next;
        }

        public async Task<OperationResult<TOut>> ExecuteAsync(TIn command)
        {
            var result = await _next.ExecuteAsync(command);

            result.OperationType = typeof(TIn);

            return result;
        }
    }
}