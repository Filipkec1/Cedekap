using Diplomski.Core.Models.Entities;
using Diplomski.Core.Repositories;
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

        /// <inheritdoc />
        public async Task<IEnumerable<Article>> GetAllWeekAndStore(Guid storeId, DateTime week)
        {
            return await GetTableQueryable()
                        .AsNoTracking()
                        .Where(a => a.StoreId == storeId && a.Week == week)
                        .ToListAsync();
        }

        /// <inheritdoc />
        public async override Task<Article> GetById(Guid id)
        {
            return await GetTableQueryable().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
