using Diplomski.Core.Models.Entities;
using Diplomski.Core.Services;
using Diplomski.Infrastructure.Parsers;
using Microsoft.AspNetCore.Mvc;
using Diplomski.Core.Requests;
using Diplomski.Core.Results;

namespace Diplomski.API.Controllers
{
    /// <summary>
    /// Defines <see cref="Article"/> api controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService articleService;

        /// <summary>
        /// Initialize a new instance of <see cref="ArticleController"/> class.
        /// </summary>
        /// <param name="service">Store Controller service.</param>
        public ArticleController(IArticleService service)
        {
            articleService = service;
        }

        /// <summary>
        /// Filter all <see cref="Article"/>s from database using <paramref name="request"/>.
        /// </summary>
        /// <param name="value">Parameters by with <see cref="Article"/>s are filtered.</param>
        /// <returns>A list of filtered <see cref="Article"/>s.</returns>
        [HttpPost]
        [Route("Filter")]
        [Produces(typeof(IEnumerable<ArticleResult>))]
        public async Task<IActionResult> FilterArticle([FromBody] ArticleFilterRequest request)
        {
            IEnumerable<ArticleResult> articleList = await articleService.FilterArticle(request);
            return Ok(articleList);
        }

        /// <summary>
        /// Read selected dbf file and convert the data to objects that are saved to the database.
        /// </summary>
        /// <param name="request">Class that contains an <see cref="IFormFile"/> for the dbf file.</param>
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadDbfFile([FromForm] ArticleDbfFileUploadRequest request)
        {
            MemoryStream memoryStream = IFormFileToMemoryStream(request.DbfFile);
            DateTime firstDayOfMonth = FirstDayOfMonth(request.DbfMonth);

            ArticleDbfParser dbfParser = new ArticleDbfParser(memoryStream, firstDayOfMonth);

            List<Article> textData = dbfParser.Read(request.StoreId);
            await articleService.AddDbfData(request.StoreId, firstDayOfMonth, textData);

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

        /// <summary>
        /// Get the first day of a selected month.
        /// </summary>
        /// <param name="month">The month that the first day of it needs to be found.</param>
        /// <returns><see cref="DateTime"/> of the first day in the month.</returns>
        private DateTime FirstDayOfMonth(DateTime month)
        {
            return new DateTime(month.Year, month.Month, 1);
        }
    }
}
