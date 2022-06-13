using _4Teammate.Domain.Models;
using _4Teammate.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace _4Teammate.API.Controllers;

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
    return Ok(_sportCategoryService.GetAllAsync());
  }

  [HttpGet("{id}")]
  public IActionResult GetById([FromRoute] int id)
  {
    return Ok(_sportCategoryService.GetByIdAsync(id));
  }

  [HttpPost]
  public IActionResult Create([FromBody] SportCategory sportCategory)
  {
    return Ok(_sportCategoryService.CreateAsync(sportCategory));
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
