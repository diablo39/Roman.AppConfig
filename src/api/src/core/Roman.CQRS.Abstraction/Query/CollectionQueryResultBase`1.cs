﻿using System;
using System.Collections.Generic;

namespace Roman.CQRS.Abstraction.Query
{
    public abstract class CollectionQueryResultBase<T> : ICollectionQueryResult<T>
    {
        public int TotalCount { get; protected set; }

        public IEnumerable<T> Items { get; protected set; }

        protected CollectionQueryResultBase(IEnumerable<T> items, int count)
        {
            Items = items;
            TotalCount = count;
        }
    }
}
