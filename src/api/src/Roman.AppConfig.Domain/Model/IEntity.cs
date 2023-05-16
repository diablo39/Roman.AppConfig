using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.AppConfig.Domain.Model
{
    public interface IEntity
    {
        DateTimeOffset CreateDate { get; }
    }

    public interface IEntity<T> : IEntity
    {
        T Id { get; }
    }
}