using System;

namespace Diplomski.Core.Requests
{
    /// <summary>
    /// Defines store request.
    /// </summary>
    public class StoreRequest
    {

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
