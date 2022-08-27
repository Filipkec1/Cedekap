using Diplomski.Core.Models.Entities;
using Diplomski.Core.Requests;
using Diplomski.Core.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diplomski.Core.Services
{
    /// <summary>
    /// Defines Article Service interface.
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// Create new <see cref="Article"/>s in the database for selected month.
        /// If the month already has <see cref="Article"/>s remove them and create new ones.
        /// </summary>
        /// <param name="storeId"><see cref="Store.Id"/> of the new <see cref="Article"/>s.</param>
        /// <param name="month">Month of the new <see cref="Article"/>s.</param>
        /// <param name="articleList">List of <see cref="Article"/> to add.</param>
        Task AddDbfData(Guid storeId, DateTime month, IEnumerable<Article> articleList);

        /// <summary>
        /// Filter all <see cref="Article"/>s from database using <paramref name="request"/>.
        /// </summary>
        /// <param name="request">Parameters by with <see cref="Article"/>s are filtered.</param>
        /// <returns>A list of filtered <see cref="ArticleResult"/>s.</returns>
        Task<IEnumerable<ArticleResult>> FilterArticle(ArticleFilterRequest request);

        /// <summary>
        /// Gets Article entity by id.
        /// </summary>
        /// <param name="id">User database id.</param>
        /// <returns>Returns <see cref="ArticleResult"/></returns>
        Task<ArticleResult> GetById(Guid id);

        /// <summary>
        /// Get all <see cref="Store"/> names from the database.
        /// </summary>
        /// <returns>A list of <see cref="Store"/> names.</returns>
        Task<IEnumerable<string>> GetStoreList();
    }
}
