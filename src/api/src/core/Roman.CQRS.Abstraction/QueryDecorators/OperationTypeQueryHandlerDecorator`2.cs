using Roman.CQRS.Abstraction.Query;
using Roman.CQRS.Abstraction.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.CQRS.Abstraction.QueryDecorators
{
    public class OperationTypeQueryHandlerDecorator<TIn, TOut> : IQueryHandler<TIn, TOut>
        where TIn : class, IQuery
    {
        private readonly IQueryHandler<TIn, TOut> _next;

        public OperationTypeQueryHandlerDecorator(IQueryHandler<TIn, TOut> next)
        {
            _next = next;
        }

        public async Task<OperationResult<TOut>> ExecuteAsync(TIn query)
        {
            var result = await _next.ExecuteAsync(query);

            result.OperationType = typeof(TIn);

            return result;
        }
    }
}