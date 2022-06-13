using _4Teammate.Domain.Models;
using _4Teammate.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _4Teammate.API.Controllers;

[Route("[controller]")]
[ApiController]
public class SportLookupController : ControllerBase
{
  private readonly ISportLookupService _sportLookupService;
  public SportLookupController(ISportLookupService sportLookupService)
  {
    _sportLookupService = sportLookupService;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    return Ok(_sportLookupService.GetAllAsync());
  }

  [HttpGet("{id}")]
  public IActionResult GetById([FromRoute] int id)
  {
    return Ok(_sportLookupService.GetByIdAsync(id));
  }

  [HttpPost]
  public IActionResult Create([FromBody] SportLookup sportLookup)
  {
    return Ok(_sportLookupService.CreateAsync(sportLookup));
  }

  [HttpPut]
  public IActionResult Update([FromBody] SportLookup sportLookup)
  {
    return Ok(_sportLookupService.Update(sportLookup));
  }

  [HttpDelete]
  public IActionResult Delete([FromBody] SportLookup sportLookup)
  {
    _sportLookupService.Delete(sportLookup);
    return Ok();
  }
}
