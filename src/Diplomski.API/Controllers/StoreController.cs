using Diplomski.Core.Models.Entities;
using Diplomski.Core.Requests;
using Diplomski.Core.Results;
using Diplomski.Core.Services;
using Diplomski.Infrastructure.Parsers;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.API.Controllers
{
    /// <summary>
    /// Defines person api controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private IStoreService storeService;

        /// <summary>
        /// Initialize a new instance of <see cref="StoreController"/> class.
        /// </summary>
        /// <param name="service">Store Controller service.</param>
        public StoreController(IStoreService service)
        {
            storeService = service;
        }

        /// <summary>
        /// Read selected dbf file and convert the data to objects that are saved to the database.
        /// </summary>
        /// <param name="request">Class that contains an <see cref="IFormFile"/> for the dbf file.</param>
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadDbfFile([FromForm] StoreDbfFileUploadRequest request)
        {
            MemoryStream memoryStream = IFormFileToMemoryStream(request.DbfFile);
            StoreDbfParser dbfParser = new StoreDbfParser(memoryStream);

            List<Article> textData = dbfParser.Read(request.StoreId, request.DbfWeek);
            await storeService.AddDbfData(request.StoreId, request.DbfWeek, textData);

            return Ok($"File {request.DbfFile.FileName} parsed and uploaded.");
        }

        /// <summary>
        /// Creates new <see cref="MemoryStream"/> from <see cref="IFormFile"/>.
        /// </summary>
        /// <param name="f"><see cref="IFormFile"/> that is going to be used in the new <see cref="MemoryStream"/>.</param>
        /// <returns>New <see cref="MemoryStream"/>.</returns>
        private MemoryStream IFormFileToMemoryStream(IFormFile f)
        {
            MemoryStream memoryStream = new MemoryStream();
            f.CopyTo(memoryStream);
            memoryStream.Position = 0;

            return memoryStream;
        }
    }
}