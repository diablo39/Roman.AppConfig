using System;
using System.Collections.Generic;
using System.Linq;

namespace Roman.CQRS.Abstraction.Result
{
    public interface IBusinessErrorResult
    {
        IEnumerable<KeyValuePair<string, string>> ValidationErrors { get; }
    }
}
