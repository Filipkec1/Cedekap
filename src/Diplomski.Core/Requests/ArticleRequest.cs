using Microsoft.AspNetCore.Http;
using System;

namespace Diplomski.Core.Requests
{
    /// <summary>
    /// Defines dbf file upload request.
    /// </summary>
    public class ArticleDbfFileUploadRequest
    {
        public IFormFile DbfFile { get; set; }
        public Guid StoreId { get; set; }
        public DateTime DbfMonth { get; set; }
    }
}
