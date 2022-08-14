using Microsoft.AspNetCore.Http;
using System;

namespace Diplomski.Core.Requests
{
    /// <summary>
    /// Defines article request.
    /// </summary>
    public class ArticleRequest
    {
        /// <summary>
        /// Defines dbf file upload request.
        /// </summary>
        public class ArticleDbfFileUploadRequest
        {
            public IFormFile DbfFile { get; set; }
            public Guid StoreId { get; set; }
            public DateTime DbfWeek { get; set; }
        }
    }
}
