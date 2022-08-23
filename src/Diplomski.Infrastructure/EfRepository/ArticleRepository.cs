using Diplomski.Core.Models.Entities;
using Diplomski.Core.Repositories;
using Diplomski.Core.Requests;
using Diplomski.Infrastructure.EfModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Infrastructure.EfRepository
{
    /// <summary>
    /// Defines repository for user.
    /// </summary>
    public class ArticleRepository : RepositoryBase<Article, Guid>, IArticleRepository
    {
        /// <summary>
        /// Initialize new instance of the <see cref="DiplomskiDbContext"/> class.
        /// </summary>
        /// <param name="context">Diplomski planning context.</param>
        public ArticleRepository(DiplomskiDbContext context) : base(context)
        { }

        /// <inheritdoc />
        public async Task<IEnumerable<Article>> FilterArticle(ArticleFilterRequest request)
        {
            ExpressionStarter<Article> predicate = PredicateBuilder.New<Article>();

            if (!string.IsNullOrEmpty(request.CodeSupplier))
            {
                predicate = predicate.And(p => p.CodeSupplier.Contains(request.CodeSupplier.ToUpper()));
            }

            if (!string.IsNullOrEmpty(request.Code))
            {
                predicate = predicate.And(p => p.Code.Contains(request.Code.ToUpper()));
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                predicate = predicate.And(p => p.Name.Contains(request.Name.ToUpper()));
            }



            return await GetTableQueryable()
                        .AsNoTracking()
                        .Where(predicate)
                        .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Article>> GetAllStoreAndMonth(Guid storeId, DateTime month)
        {
            return await GetTableQueryable()
                        .AsNoTracking()
                        .Where(a => a.StoreId == storeId && a.Month == month)
                        .ToListAsync();
        }

        /// <inheritdoc />
        public async override Task<Article> GetById(Guid id)
        {
            return await GetTableQueryable().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
