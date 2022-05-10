using Diplomski.Core.Models.Entities;
using Diplomski.Core.Requests;
using Diplomski.Core.Services;
using Diplomski.Infrastructure.Parsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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
        /// Read selected csv file and convert the data to objects that are saved to the database.
        /// </summary>
        /// <param name="request">Class that contains an <see cref="IFormFile"/> for the text file.</param>
        /// <returns><see cref="CreatedResult"/></returns>
        [HttpPost]
        [Route("Upload")]
        [Produces(typeof(CreatedResult))]
        public async Task<IActionResult> UploadTextFile([FromForm] StoreCsvFileUploadRequest request)
        {
            MemoryStream memoryStream = IFormFileToMemoryStream(request.CsvFile);
            StoreCsvParser csvParser = new StoreCsvParser(memoryStream);

            List<Article> textData = csvParser.Read();
            await storeService.AddCsvData(textData);

            return Created(request.CsvFile.FileName, null);
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
