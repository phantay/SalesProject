using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DALayer.Infrastructure
{
    /// <summary>
    /// Interface IRepositoryBase
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IEnumerable&lt;TEntity&gt;.</returns>
        IEnumerable<TEntity> Get(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          string includeProperties = "");
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        TEntity GetByID(object id);
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(TEntity entity);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(object id);
        /// <summary>
        /// Deletes the specified entity to delete.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        void Delete(TEntity entityToDelete);
        /// <summary>
        /// Updates the specified entity to update.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        void Update(TEntity entityToUpdate);
        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        void Dispose(bool disposing);
        /// <summary>
        /// Disposes this instance.
        /// </summary>
        void Dispose();
    }
}
