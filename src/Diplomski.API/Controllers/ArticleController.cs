using Diplomski.Core.Models.Entities;
using Diplomski.Core.Services;
using Diplomski.Infrastructure.Parsers;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static Diplomski.Core.Requests.ArticleRequest;

namespace Diplomski.API.Controllers
{
    /// <summary>
    /// Defines <see cref="Article"/> api controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private IArticleService articleService;

        /// <summary>
        /// Initialize a new instance of <see cref="ArticleController"/> class.
        /// </summary>
        /// <param name="service">Store Controller service.</param>
        public ArticleController(IArticleService service)
        {
            articleService = service;
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
            DateTime firstDayOfWeek = FirstDayOfWeek(request.DbfWeek);

            ArticleDbfParser dbfParser = new ArticleDbfParser(memoryStream, firstDayOfWeek);

            List<Article> textData = dbfParser.Read(request.StoreId, FirstDayOfWeek(request.DbfWeek));
            await articleService.AddDbfData(request.StoreId, firstDayOfWeek, textData);

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
        /// Get the first day of a selected week.
        /// </summary>
        /// <param name="week">The week that the first day of it needs to be found.</param>
        /// <returns><see cref="DateTime"/> of the first day in the week.</returns>
        private DateTime FirstDayOfWeek(DateTime week)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            int diff = week.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return week.AddDays(-diff).Date;
        }
    }
}
