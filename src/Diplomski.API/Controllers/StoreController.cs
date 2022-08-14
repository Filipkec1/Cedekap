using Diplomski.Core.Models.Entities;
using Diplomski.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Diplomski.API.Controllers
{
    /// <summary>
    /// Defines <see cref="Store"/> api controller.
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
    }
}