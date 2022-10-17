using Cedekap.Core.Models.Entities;
using Cedekap.Core.Requests;
using Cedekap.Core.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cedekap.Core.Services
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
        /// Sort all <paramref name="articleResultList"/> by using <paramref name="request"/>.
        /// </summary>
        /// <param name="request">Parameters by witch the <paramref name="articleResultList"/> will be sorted.</param>
        /// <param name="articleResultList">List of <see cref=ArticleResult""/> that are going to be sorted.</param>
        /// <returns>List of sorted <see cref="ArticleResult"/> from <paramref name="articleResultList"/>.</returns>
        IEnumerable<object> SortArticle(ArticleShowRequest request, IEnumerable<ArticleResult> articleResultList);

        /// <summary>
        /// Get all <see cref="Store"/>s from the database.
        /// </summary>
        /// <returns>A list of <see cref="Store"/>.</returns>
        Task<IEnumerable<Store>> GetStoreList();
    }
}
