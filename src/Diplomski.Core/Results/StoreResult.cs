using Diplomski.Core.Models.Entities;
using System;

namespace Diplomski.Core.Results
{
    /// <summary>
    /// Defines store result class.
    /// </summary>
    public class StoreResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string Place { get; set; }


        /// <summary>
        /// Initializes a new instance of <see cref="StoreResult"/>.
        /// </summary>s
        /// <param name="store">Store.</param>
        public StoreResult(Store store)
        {
            this.Id = store.Id;
            this.Name = store.Name; 
            this.PostCode = store.PostCode; 
            this.Address = store.Address; 
            this.Place = store.Place; 
        }
    }
}
