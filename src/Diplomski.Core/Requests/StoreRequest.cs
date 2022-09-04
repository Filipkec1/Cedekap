using System;

namespace Diplomski.Core.Requests
{
    /// <summary>
    /// Defines store request.
    /// </summary>
    public class StoreCreateUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string Place { get; set; }
    }
}
