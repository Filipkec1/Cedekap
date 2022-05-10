using Diplomski.Core.Models.Entities;
using Diplomski.Core.Requests;
using Diplomski.Core.Results;
using Diplomski.Core.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diplomski.Core.Services.Implementations
{
    /// <summary>
    /// Defines item service.
    /// </summary>
    public class StoreService : ServiceBase, IStoreService
    {
        /// <summary>
        /// Initilizes new instance of <see cref="StoreService"/>
        /// </summary>
        /// <param name="unitOfWork">Unit of work.</param>
        public StoreService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task AddCsvData(IEnumerable<Article> peopleList)
        {

            throw new NotImplementedException();
        }

        public Task<StoreResult> Create(StoreCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StoreResult>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<StoreResult> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(StoreUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
