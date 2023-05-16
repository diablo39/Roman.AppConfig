using Roman.AppConfig.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Roman.AppConfig.Domain.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Check if an entity exists
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exists(Func<T, bool> predicate);

        // Check if an entity exists
        bool Exists<K>(Func<K, bool> predicate)
            where K : class, T;

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Get an entity by its key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        T Get(params object[] keyValues);

        /// <summary>
        /// Update child collection of the entity
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <param name="modifiedCollection"></param>
        /// <param name="updater"></param>
        void UpdateChildCollection<TChild, TKey>(T entity, Expression<Func<T, IEnumerable<TChild>>> property, IEnumerable<TChild> modifiedCollection, Action<TChild, TChild> updater)
            where TChild : IEntity<TKey>;
    }
}