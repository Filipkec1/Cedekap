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
        /// Get all stores from the database.
        /// </summary>
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetStoreList()
        {
            IEnumerable<StoreResult> storeResultList = await storeService.GetAll();
            return PartialView("_StoreList", storeResultList.OrderBy(x => int.Parse(x.Name.Remove(0,1))));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
