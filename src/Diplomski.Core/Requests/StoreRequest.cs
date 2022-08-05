using Microsoft.AspNetCore.Http;
using System;

namespace Diplomski.Core.Requests
{
    /// <summary>
    /// Defines store request.
    /// </summary>
    public class StoreRequest
    {
        public string Name { get; set; }
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

    /// <summary>
    /// Defines csv file upload request.
    /// </summary>
    public class StoreCsvFileUploadRequest
    {
        public IFormFile CsvFile { get; set; }
        public Guid StoreId { get; set; }
    }
}
