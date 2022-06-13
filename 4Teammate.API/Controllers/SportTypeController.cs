using _4Teammate.Domain.Models;
using _4Teammate.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _4Teammate.API.Controllers;

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
    return Ok(_sportTypeService.GetAllAsync());
  }

  [HttpGet("{id}")]
  public IActionResult GetById([FromRoute] int id)
  {
    return Ok(_sportTypeService.GetByIdAsync(id));
  }

  [HttpPost]
  public IActionResult Create([FromBody] SportType sportType)
  {
    return Ok(_sportTypeService.CreateAsync(sportType));
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
