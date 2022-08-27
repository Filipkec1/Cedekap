using Diplomski.Core.Exceptions;
using Diplomski.Core.Models.Entities;
using Diplomski.Core.Requests;
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
        public async Task AddDbfData(Guid storeId, DateTime month, IEnumerable<Article> articleList)
        {
            IEnumerable<Article> articleToDelete = await unitOfWork.Article.GetAllStoreAndMonth(storeId, month);

            if (articleToDelete.Any())
            {
                unitOfWork.Article.DeleteRange(articleToDelete);
                await unitOfWork.Commit();
            }

            await unitOfWork.Article.AddRange(articleList);
            await unitOfWork.Commit();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ArticleResult>> FilterArticle(ArticleFilterRequest request)
        {
            IEnumerable<Article> articleList = await unitOfWork.Article.FilterArticle(request);
            return articleList.Select(x => new ArticleResult(x));
        }

        /// <inheritdoc />
        public async Task<ArticleResult> GetById(Guid id)
        {
            Article article = await unitOfWork.Article.GetById(id);
            if (article is null)
            {
                throw new EntityNotFoundException(typeof(Article), id);
            }

            return new ArticleResult(article);
        }

        /// <inheritdoc />
        async Task<IEnumerable<string>> IArticleService.GetStoreList()
        {
            return await unitOfWork.Store.GetAllStoreNames();
        }
    }
}
