using System;
using System.Linq;

namespace Roman.CQRS.Abstraction.Result
{
    public interface ISuccessResult<TOut>
    {
        TOut? Result { get; }
    }
}