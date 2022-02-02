using _4Teammate.API.Models;
using _4Teammate.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _4Teammate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILookupCategoryService _lookupCategoryService;
        public HomeController(ILookupCategoryService lookupCategoryService)
        {
            _lookupCategoryService = lookupCategoryService;
        }

        [HttpGet]
        public IActionResult GetInfo() {
            return Ok(_lookupCategoryService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] LookupCategory lookupCategory) {
            return Ok(_lookupCategoryService.Create(lookupCategory));
        }

    }
}
