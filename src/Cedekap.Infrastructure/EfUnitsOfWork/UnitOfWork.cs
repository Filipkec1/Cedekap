using Cedekap.Core.Models.Entities;
using Cedekap.Core.Repositories;
using Cedekap.Core.UnitsOfWork;
using Cedekap.Infrastructure.EfModels;
using Cedekap.Infrastructure.EfRepository;
using System;
using System.Threading.Tasks;

namespace Cedekap.Infrastructure.EfUnitsOfWork
{
    /// <summary>
    /// Defines unit of work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CedekapDbContext context;

        private IStoreRepository storeRepository;
        private IArticleRepository articleRepository;

        public UnitOfWork(CedekapDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task Commit() => _ = await context.SaveChangesAsync();

        /// <inheritdoc/>
        public IDatabaseTransaction GetNewTransaction()
        {
            var transaction = new DatabaseTransaction(context);
            transaction.CreateTransaction();

            return transaction;
        }

        /// <inheritdoc/>

        public IStoreRepository Store
        {
            get
            {
                if(storeRepository is null)
                {
                    storeRepository = new StoreRepository(context);
                }

                return storeRepository;
            }
        }

        public IArticleRepository Article
        {
            get
            {
                if (articleRepository is null)
                {
                    articleRepository = new ArticleRepository(context);
                }

                return articleRepository;
            }
        }

        /// <inheritdoc/>
        public IRepository<T, TKey> GetRepository<T, TKey>() where T : class
        {
            var type = typeof(T);

            switch (true)
            {
                case bool _ when type == typeof(Store):
                    return Store as IRepository<T, TKey>;
                case bool _ when type == typeof(Article):
                    return Article as IRepository<T, TKey>;
                default:
                    throw new ArgumentException("The requested type doesn't have an exposed repository");
            }
        }
    }
}
