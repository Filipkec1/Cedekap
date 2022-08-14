using Diplomski.Core.Models.Entities;
using Diplomski.Core.Results;
using Diplomski.Core.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Core.Services.Implementations
{
    /// <summary>
    /// Defines <see cref="Store"/> service.
    /// </summary>
    public class ArticleService : ServiceBase, IArticleService
    {
        /// <summary>
        /// Initilizes new instance of <see cref="ArticleService"/>
        /// </summary>
        /// <param name="unitOfWork">Unit of work.</param>
        public ArticleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        /// <inheritdoc />
        public async Task AddDbfData(Guid storeId, DateTime week, IEnumerable<Article> articleList)
        {
            IEnumerable<Article> articleToDelete = await unitOfWork.Article.GetAllWeekAndStore(storeId, week);

            if (articleToDelete.Any())
            {
                unitOfWork.Article.DeleteRange(articleToDelete);
                await unitOfWork.Commit();
            }

            await unitOfWork.Article.AddRange(articleList);
            await unitOfWork.Commit();
        }

        /// <inheritdoc />
        public Task<ArticleResult> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
