using Diplomski.Core.Models.Entities;
using Diplomski.Core.Requests;
using Diplomski.Core.Results;
using Diplomski.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.Web.Controllers
{
    /// <summary>
    /// Defines <see cref="Store"/> MVC controller.
    /// </summary>
    [Route("Store")]
    public class StoreController : Controller
    {
        private readonly IStoreService storeService;

        /// <summary>
        /// Initialize a new instance of <see cref="StoreController"/> class.
        /// </summary>
        /// <param name="service">Store Controller service.</param>
        public StoreController(IStoreService service)
        {
            storeService = service;
        }

        /// <summary>
        /// Get the modal for creating a new <see cref="Store"/>
        /// </summary>
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return PartialView("_CreateOrEdit");
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(StoreCreateUpdateRequest request)
        {
            await storeService.Create(request);
            return Ok();
        }

        /// <summary>
        /// Get all stores from the database.
        /// </summary>
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetStoreList()
        {
            IEnumerable<StoreResult> storeResultList = await storeService.GetAll();
            storeResultList = storeResultList.OrderBy(x => int.Parse(x.Name.Remove(0, 1)));
            return PartialView("_StoreList", storeResultList);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
