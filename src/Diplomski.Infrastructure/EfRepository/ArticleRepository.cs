using Diplomski.Core.Models.Entities;
using Diplomski.Core.Repositories;
using Diplomski.Core.Requests;
using Diplomski.Infrastructure.EfModels;
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

        public Task<IEnumerable<Article>> FilterArticle(ArticleFilterRequest request)
        {
            throw new NotImplementedException();
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
