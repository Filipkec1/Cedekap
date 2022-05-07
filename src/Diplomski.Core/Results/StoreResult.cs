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

        /// <summary>
        /// Initializes a new instance of <see cref="StoreResult"/>.
        /// </summary>s
        /// <param name="store">Store.</param>
        public StoreResult(Store store)
        {
            Id = store.Id;
        }
    }
}
