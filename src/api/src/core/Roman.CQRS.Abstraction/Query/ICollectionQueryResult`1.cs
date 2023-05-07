using System;
using System.Collections.Generic;

namespace Roman.CQRS.Abstraction.Query
{
    public interface ICollectionQueryResult<T>
    {
        int TotalCount { get; }

        IEnumerable<T> Items { get; }
    }
}
