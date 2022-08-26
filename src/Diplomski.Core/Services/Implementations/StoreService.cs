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
    public class StoreService : ServiceBase, IStoreService
    {
        /// <summary>
        /// Initilizes new instance of <see cref="StoreService"/>
        /// </summary>
        /// <param name="unitOfWork">Unit of work.</param>
        public StoreService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        /// <inheritdoc />
        public async Task<StoreResult> Create(StoreCreateRequest request)
        {
            Store newStore = new Store()
            {
                Name = request.Name
            };

            await unitOfWork.Store.Add(newStore);
            await unitOfWork.Commit();

            return new StoreResult(newStore);
        }

        /// <inheritdoc />
        public async Task Delete(Guid id)
        {
            Store store = await unitOfWork.Store.GetById(id);
            if(store is null)
            {
                throw new EntityNotFoundException(typeof(Store), id);
            }

            unitOfWork.Store.Delete(store);
            await unitOfWork.Commit();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<StoreResult>> GetAll()
        {
            IEnumerable<Store> peopleList = await unitOfWork.Store.GetAll();
            return peopleList.Select(p => new StoreResult(p));
        }

        /// <inheritdoc />
        public async Task<StoreResult> GetById(Guid id)
        {
            Store store = await unitOfWork.Store.GetById(id);
            if (store is null)
            {
                throw new EntityNotFoundException(typeof(Store), id);
            }

            return new StoreResult(store);
        }

        /// <inheritdoc />
        public async Task Update(StoreUpdateRequest request)
        {
            Store store = await unitOfWork.Store.GetById(request.Id);
            if (store is null)
            {
                throw new EntityNotFoundException(typeof(Store), request.Id);
            }

            unitOfWork.Store.Update(store);
            await unitOfWork.Commit();
        }
    }
}
