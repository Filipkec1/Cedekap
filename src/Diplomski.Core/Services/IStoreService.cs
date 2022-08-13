﻿using Diplomski.Core.Models.Entities;
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
        /// Create new <see cref="Article"/>s in the database for selected week.
        /// If the week already has <see cref="Article"/>s remove them and create new ones.
        /// </summary>
        /// <param name="storeId"><see cref="Store.Id"/> of the new <see cref="Article"/>s.</param>
        /// <param name="week">Week of the new <see cref="Article"/>s.</param>
        /// <param name="articleList">List of <see cref="Article"/> to add.</param>
        Task AddDbfData( Guid storeId, DateTime week, IEnumerable<Article> articleList);
    }
}
