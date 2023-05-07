using Roman.CQRS.Abstraction.Result;

namespace Roman.CQRS.Abstraction.Command
{
    public interface ICommandHandler<TIn, TOut>
        where TIn : ICommand
    {
        Task<OperationResult<TOut>> ExecuteAsync(TIn command);
    }
}