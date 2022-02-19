using _4Teammate.API.Models;
using _4Teammate.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Teammate.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SportCategoryController : ControllerBase
    {
        private readonly ISportCategoryService _sportCategoryService;
        public SportCategoryController(ISportCategoryService sportCategoryService)
        {
            _sportCategoryService = sportCategoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_sportCategoryService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_sportCategoryService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] SportCategory sportCategory)
        {
            return Ok(_sportCategoryService.Create(sportCategory));
        }

        [HttpPut]
        public IActionResult Update([FromBody] SportCategory sportCategory)
        {
            return Ok(_sportCategoryService.Update(sportCategory));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] SportCategory sportCategory)
        {
            _sportCategoryService.Delete(sportCategory);
            return Ok();
        }
    }
}
