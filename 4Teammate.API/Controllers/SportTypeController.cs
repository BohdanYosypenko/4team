using _4Teammate.API.Models;
using _4Teammate.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _4Teammate.API.Controllers {
  [Route("[controller]")]
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

        [HttpGet("category/{id}")]
        public IActionResult GetByCategoryId([FromRoute] int id)
        {
            return Ok(_sportTypeService.GetByCategoryId(id));
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
