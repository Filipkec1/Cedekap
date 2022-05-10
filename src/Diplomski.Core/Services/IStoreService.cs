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
        /// Gets all people.
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
        /// Creates new Store in database.
        /// </summary>
        /// <param name="request"><see cref="StoreCreateRequest"/></param>
        /// <returns>Returns <see cref="StoreResult"/></returns>
        Task<StoreResult> Create(StoreCreateRequest request);

        /// <summary>
        /// Updates Store data.
        /// </summary>
        /// <param name="request"><see cref="StoreUpdateRequest"/></param>
        Task Update(StoreUpdateRequest request);

        /// <summary>
        /// Deletes Store from database.
        /// </summary>
        /// <param name="id">Store database id.</param>
        Task Delete(Guid id);

        /// <summary>
        /// Create new <see cref="Article"/> in the database.
        /// Update <see cref="Article"/>s that are in the database.
        /// </summary>
        /// <param name="peopleList">List of <see cref="Article"/> to add or update.</param>
        Task AddCsvData(IEnumerable<Article> peopleList);
    }
}
