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
        [Route("CreateOrEdit")]
        public IActionResult CreateOrEdit()
        {
            return PartialView("_CreateOrEdit");
        }

        [HttpPost]
        [Route("CreateOrEdit")]
        public async Task<IActionResult> CreateOrEdit(StoreCreateUpdateRequest request)
        {
            await storeService.CreateOrUpdate(request);

            IEnumerable<StoreResult> storeResultList = await GetStoreResultList();
            return PartialView("_StoreList", storeResultList);
        }

        //[HttpGet]
        //[Route("Edit")]
        //public async Task<IActionResult> Edit(string id)
        //{
        //    Guid guid = Guid.Parse(id);

        //    StoreResult store = await storeService.GetById(guid);
        //    return PartialView("_CreateOrEdit", store);
        //}

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(string? id)
        {
            //Guid guid = Guid.Parse(id);

            //StoreResult store = await storeService.GetById(guid);
            //return PartialView("_CreateOrEdit", store);
            return Ok();
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            //Guid guid = Guid.Parse(id);

            //StoreResult store = await storeService.GetById(guid);
            //return PartialView("_CreateOrEdit", store);

            return Ok();
        }

        /// <summary>
        /// Get all stores from the database.
        /// </summary>
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetStoreList()
        {
            IEnumerable<StoreResult> storeResultList = await GetStoreResultList();
            return PartialView("_StoreList", storeResultList);
        }

        /// <summary>
        /// Get all <see cref="Store"/>s from the database and order them by name.
        /// </summary>
        /// <returns>A list of <see cref="StoreResult"/>s.</returns>
        private async Task<IEnumerable<StoreResult>> GetStoreResultList()
        {
            IEnumerable<StoreResult> storeResultList = await storeService.GetAll();
            storeResultList = storeResultList.OrderBy(x => int.Parse(x.Name.Remove(0, 1)));
            return storeResultList; 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
