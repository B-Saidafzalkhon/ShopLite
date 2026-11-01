using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopLite.Api.Data;
using ShopLite.Api.Entities;

namespace ShopLite.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ShopDbContext _db;

    public CategoriesController(ShopDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _db.Categories.ToListAsync();
        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if (category is null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Category category)
    {
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }
}