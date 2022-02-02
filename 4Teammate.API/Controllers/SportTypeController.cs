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
    [Route("api/[controller]")]
    [ApiController]
    public class SportTypeController : ControllerBase
    {
        private readonly ISportTypeService _sportTypeService;
        public SportTypeController(ISportTypeService sportTypeService)
        {
            _sportTypeService = sportTypeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_sportTypeService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_sportTypeService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] SportType sportType)
        {
            return Ok(_sportTypeService.Create(sportType));
        }

        [HttpPut]
        public IActionResult Update([FromBody] SportType sportType)
        {
            return Ok(_sportTypeService.Update(sportType));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] SportType sportType)
        {
            _sportTypeService.Delete(sportType);
            return Ok();
        }
    }
}
