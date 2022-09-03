using System;

namespace Diplomski.Core.Requests
{
    /// <summary>
    /// Defines store request.
    /// </summary>
    public class StoreRequest
    {
        public string Name { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }

    }

    /// <summary>
    /// Defines store create request.
    /// </summary>
    public class StoreCreateRequest : StoreRequest
    {

    }

    /// <summary>
    /// Defines store update request.
    /// </summary>
    public class StoreUpdateRequest : StoreRequest
    {
        public Guid Id { get; set; }
    }
}
