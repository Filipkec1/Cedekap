using Diplomski.Core.Models.Entities;
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
        /// Gets Article entity by id.
        /// </summary>
        /// <param name="id">User database id.</param>
        /// <returns>Returns <see cref="ArticleResult"/></returns>
        Task<ArticleResult> GetById(Guid id);
    }
}
