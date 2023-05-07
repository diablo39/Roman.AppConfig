using System;
using System.Linq;

namespace Roman.CQRS.Abstraction.Result
{
    public interface IServerErrorResult
    {
        Exception? Exception { get; }
    }
}