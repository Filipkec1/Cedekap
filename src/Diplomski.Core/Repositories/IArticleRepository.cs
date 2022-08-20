using Diplomski.Core.Models.Entities;
using Diplomski.Core.Requests;
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
        /// Filter all <see cref="Article"/>s from database using <paramref name="request"/>.
        /// </summary>
        /// <param name="value">Parameters by with <see cref="Article"/>s are filtered.</param>
        /// <returns>A list of filtered <see cref="Article"/>s.</returns>
        Task<IEnumerable<Article>> FilterArticle(ArticleFilterRequest request);

        /// <summary>
        /// Get all <see cref="Article"/>s that belong to <see cref="Store"/> with Id <paramref name="storeId"/> and belong to <paramref name="month"/>.
        /// </summary>
        /// <param name="storeId">Id of the <see cref="Store"/> that the <see cref="Article"/>s belong to.</param>
        /// <param name="month">Month of the <see cref="Article.Month"/></param>
        /// <returns></returns>
        Task<IEnumerable<Article>> GetAllStoreAndMonth(Guid storeId, DateTime month);

    }
}
