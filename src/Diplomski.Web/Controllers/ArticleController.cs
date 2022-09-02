using Diplomski.Core.Models.Entities;
using Diplomski.Core.Requests;
using Diplomski.Core.Results;
using Diplomski.Core.Services;
using Diplomski.Infrastructure.Parsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Text.Json;

namespace Diplomski.Web.Controllers
{
    /// <summary>
    /// Defines <see cref="Article"/> MVC controller.
    /// </summary>
    [Route("Article")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IMemoryCache cache;
        private CancellationTokenSource resetCacheToken = new();

        /// <summary>
        /// Initialize a new instance of <see cref="ArticleController"/> class.
        /// </summary>
        /// <param name="service">Article Controller service.</param>
        public ArticleController(IArticleService service, IMemoryCache cache)
        {
            articleService = service;
            this.cache = cache;
        }

        /// <summary>
        /// Call the view responsible for displaying the chart.
        /// </summary>
        [HttpGet]
        [Route("Graf")]
        public async Task<IActionResult> ArticleChartView()
        {
            await GetStores();
            GetSortList();
            GetOrderList();
            return View();
        }

        /// <summary>
        /// Call the view responsible for dbf upload.
        /// </summary>
        [HttpGet]
        [Route("Ucitavanje")]
        public async Task<IActionResult> ArticleUploadView()
        {
            await GetStores();
            return View();
        }

        /// <summary>
        /// Filter and sort all <see cref="Article"/>s from database using <paramref name="request"/>.
        /// </summary>
        /// <param name="request">Parameters by with <see cref="Article"/>s are filtered and sorted.</param>
        /// <returns>Http status code <see cref="HttpStatusCode.OK"/>.</returns>
        [HttpPost]
        [Route("Filter")]
        public async Task<IActionResult> FilterArticle([FromForm] ArticleShowRequest request)
        {
            ArticleFilterRequest filterRequest = new ArticleFilterRequest(request);
            IEnumerable<ArticleResult> articleResultList = await GetArticleList(filterRequest);

            IEnumerable<object> data = articleService.SortArticle(request, articleResultList);
            return Ok(data);
        }

        /// <summary>
        /// Get for the first time the "_ArticleChart" PartialView.
        /// </summary>
        [HttpGet]
        [Route("Chart")]
        public IActionResult GetArticleChartPartialView()
        {
            return PartialView("_ArticleChart");
        }

        [HttpPost]
        [Route("List")]
        public IActionResult ListArticles(string jsonString)
        {
            List<ArticleResult> articleResultList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ArticleResult>>(jsonString);
            return PartialView("_ArticleList", articleResultList);
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
        /// Get the first day of a selected month.
        /// </summary>
        /// <param name="month">The month that the first day of it needs to be found.</param>
        /// <returns><see cref="DateTime"/> of the first day in the month.</returns>
        private DateTime FirstDayOfMonth(DateTime month)
        {
            return new DateTime(month.Year, month.Month, 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="requestJson"></param>
        /// <returns>A list of <see cref="ArticleResult"/>s.</returns>
        private async Task<IEnumerable<ArticleResult>> GetArticleList(ArticleFilterRequest request)
        {
            string requestJson = JsonSerializer.Serialize(request);

            //If request is not cached get it from the database and then cache it.
            if (!cache.TryGetValue(request, out IEnumerable<ArticleResult> articleList))
            {
                articleList = await articleService.FilterArticle(request);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(600))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);

                cache.Set(requestJson, articleList, cacheEntryOptions);
            }

            return articleList;
        }

        /// <summary>
        /// Get all the stores from the database.
        /// </summary>
        private async Task GetStores()
        {
            IEnumerable<Store> storeList = await articleService.GetStoreList();

            List<SelectListItem> selectItems = new List<SelectListItem>();
            selectItems = storeList.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            ViewBag.Stores = selectItems;
        }

        /// <summary>
        /// Get the list by with the filter resuslt can be sorted.
        /// </summary>
        private void GetSortList()
        {
            List<SelectListItem> selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem("Potražnja", "Demand", true));
            selectItems.Add(new SelectListItem("Izlaz", "Exit"));
            selectItems.Add(new SelectListItem("Cijena", "Price"));
            selectItems.Add(new SelectListItem("Nabavna cijena", "BuyPrice"));

            ViewBag.SortList = selectItems;
        }

        /// <summary>
        /// Get the list by with the filter resuslt can be ordered.
        /// </summary>
        private void GetOrderList()
        {
            List<SelectListItem> selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem("Gornje", "false", true));
            selectItems.Add(new SelectListItem("Donje", "true"));

            ViewBag.OrderList = selectItems;
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