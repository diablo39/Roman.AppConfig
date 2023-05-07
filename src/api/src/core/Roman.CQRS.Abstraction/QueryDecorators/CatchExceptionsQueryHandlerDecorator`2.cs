using Roman.CQRS.Abstraction.Exceptions;
using Roman.CQRS.Abstraction.Query;
using Roman.CQRS.Abstraction.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.CQRS.Abstraction.QueryDecorators
{
    public class CatchExceptionsQueryHandlerDecorator<TIn, TOut> : IQueryHandler<TIn, TOut>
            where TIn : class, IQuery
    {
        private readonly IQueryHandler<TIn, TOut> _next;
        private readonly ILogger _logger;

        public CatchExceptionsQueryHandlerDecorator(IQueryHandler<TIn, TOut> next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("QUERY HANDLER");
        }

        public async Task<OperationResult<TOut>> ExecuteAsync(TIn query)
        {
            try
            {
                return await _next.ExecuteAsync(query);
            }
            catch (BusinessException ex)
            {
                return OperationResult.BusinessError<TOut>(ex.ValidationErrors);
            }
            catch (ArgumentException ex)
            {
                return OperationResult.BusinessError<TOut>(new KeyValuePair<string, string>(ex.ParamName ?? "", ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing query");
                return OperationResult.ServerError<TOut>(ex);
            }
        }
    }
}