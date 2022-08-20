using Diplomski.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diplomski.Core.Repositories
{
    /// <summary>
    /// Defines article repository interface.
    /// </summary>
    public interface IArticleRepository : IRepository<Article, Guid>
    {
        /// <summary>
        /// Get all <see cref="Article"/>s that belong to <see cref="Store"/> with Id <paramref name="storeId"/> and belong to <paramref name="month"/>.
        /// </summary>
        /// <param name="storeId">Id of the <see cref="Store"/> that the <see cref="Article"/>s belong to.</param>
        /// <param name="month">Month of the <see cref="Article.Month"/></param>
        /// <returns></returns>
        Task<IEnumerable<Article>> GetAllStoreAndMonth(Guid storeId, DateTime month);
    }
}
