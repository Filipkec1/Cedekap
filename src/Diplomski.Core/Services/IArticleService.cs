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
        /// Gets all people.
        /// </summary>
        /// <returns>List of <see cref="ArticleResult"/></returns>
        Task<IEnumerable<ArticleResult>> GetAll();

        /// <summary>
        /// Gets Article entity by id.
        /// </summary>
        /// <param name="id">User database id.</param>
        /// <returns>Returns <see cref="ArticleResult"/></returns>
        Task<ArticleResult> GetById(Guid id);
    }
}
