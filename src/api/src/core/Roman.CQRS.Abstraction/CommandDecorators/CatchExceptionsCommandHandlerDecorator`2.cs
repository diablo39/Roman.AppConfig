using Roman.CQRS.Abstraction.Command;
using Roman.CQRS.Abstraction.Exceptions;
using Roman.CQRS.Abstraction.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.CQRS.Abstraction.CommandDecorators
{
    public class CatchExceptionsCommandHandlerDecorator<TIn, TOut> : ICommandHandler<TIn, TOut>
            where TIn : class, ICommand
    {
        private readonly ICommandHandler<TIn, TOut> _next;
        private readonly ILogger<CatchExceptionsCommandHandlerDecorator<TIn, TOut>> _logger;

        public CatchExceptionsCommandHandlerDecorator(ICommandHandler<TIn, TOut> next, ILogger<CatchExceptionsCommandHandlerDecorator<TIn, TOut>> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task<OperationResult<TOut>> ExecuteAsync(TIn command)
        {
            try
            {
                return await _next.ExecuteAsync(command);
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
                _logger.LogError(ex, "Exception while invoking command handler: {handler}", _next.GetType());
                return OperationResult.ServerError<TOut>(ex);
            }
        }
    }
}