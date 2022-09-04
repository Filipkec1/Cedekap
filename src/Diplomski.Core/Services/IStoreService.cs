using Diplomski.Core.Models.Entities;
using Diplomski.Core.Requests;
using Diplomski.Core.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diplomski.Core.Services
{
    /// <summary>
    /// Defines Store Service interface.
    /// </summary>
    public interface IStoreService
    {
        /// <summary>
        /// Gets all Stores.
        /// </summary>
        /// <returns>List of <see cref="StoreResult"/></returns>
        Task<IEnumerable<StoreResult>> GetAll();

        /// <summary>
        /// Gets Store entity by id.
        /// </summary>
        /// <param name="id">User database id.</param>
        /// <returns>Returns <see cref="StoreResult"/></returns>
        Task<StoreResult> GetById(Guid id);

        /// <summary>
        /// Create new <see cref="Store"/> if <paramref name="request"/> Id is empty.
        /// Update <see cref="Store"/> if <paramref name="request"/> Id has value.
        /// </summary>
        /// <param name="request"><see cref="StoreCreateUpdateRequest"/></param>
        Task CreateOrUpdate(StoreCreateUpdateRequest request);

        /// <summary>
        /// Deletes Store from database.
        /// </summary>
        /// <param name="id">Store database id.</param>
        Task Delete(Guid id);
    }
}
