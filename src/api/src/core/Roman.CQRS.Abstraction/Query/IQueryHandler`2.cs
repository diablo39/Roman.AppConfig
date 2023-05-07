using Roman.CQRS.Abstraction.Result;
using System;
using System.Threading.Tasks;

namespace Roman.CQRS.Abstraction.Query
{
    public interface IQueryHandler<T, R>
        where T : IQuery
    {
        Task<OperationResult<R>> ExecuteAsync(T query);
    }
}
