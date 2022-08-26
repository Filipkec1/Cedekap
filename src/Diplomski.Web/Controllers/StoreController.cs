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

        public IActionResult Index()
        {
            return View();
        }
    }
}
