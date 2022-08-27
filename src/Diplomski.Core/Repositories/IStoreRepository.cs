using Diplomski.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diplomski.Core.Repositories
{
    /// <summary>
    /// Defines store repository interface.
    /// </summary>
    public interface IStoreRepository : IRepository<Store, Guid>
    {
        /// <summary>
        /// Get all <see cref="Store"/> names from the database.
        /// </summary>
        /// <returns>A list of all <see cref="Store"/> names.</returns>
        Task<IEnumerable<string>> GetAllStoreNames();
    }
}
