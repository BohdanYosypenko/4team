using _4Teammate.Domain.Models;
using _4Teammate.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _4Teammate.API.Controllers;

[Route("[controller]")]
[ApiController]
public class LookupCategoryController : ControllerBase
{
    private readonly ILookupCategoryService _lookupCategoryService;
    public LookupCategoryController(ILookupCategoryService lookupCategoryService)
    {
        _lookupCategoryService = lookupCategoryService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_lookupCategoryService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        return Ok(_lookupCategoryService.GetByIdAsync(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] LookupCategory lookupCategory)
    {
        return Ok(_lookupCategoryService.CreateAsync(lookupCategory));
    }

    [HttpPut]
    public IActionResult Update([FromBody] LookupCategory lookupCategory)
    {
        return Ok(_lookupCategoryService.Update(lookupCategory));
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] LookupCategory lookupCategory)
    {
        _lookupCategoryService.Delete(lookupCategory);
        return Ok();
    }
}
