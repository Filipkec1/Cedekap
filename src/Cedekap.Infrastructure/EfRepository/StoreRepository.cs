using Cedekap.Core.Models.Entities;
using Cedekap.Core.Repositories;
using Cedekap.Infrastructure.EfModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cedekap.Infrastructure.EfRepository
{
    /// <summary>
    /// Defines repository for user.
    /// </summary>
    public class StoreRepository : RepositoryBase<Store, Guid>, IStoreRepository
    {
        /// <summary>
        /// Initialize new instance of the <see cref="CedekapDbContext"/> class.
        /// </summary>
        /// <param name="context">Cedekap planning context.</param>
        public StoreRepository(CedekapDbContext context) : base(context)
        { }

        /// <inheritdoc />
        public async override Task<Store> GetById(Guid id)
        {
            return await GetTableQueryable().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
