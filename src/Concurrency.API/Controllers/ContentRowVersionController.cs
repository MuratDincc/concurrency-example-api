using Concurrency.API.Context;
using Concurrency.API.Models.ContentRowVersion.Request;
using Concurrency.API.Models.ContentRowVersion.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Concurrency.API.Controllers;

[Route("api/content-row-version")]
[ApiController]
public class ContentRowVersionController : ControllerBase
{
    #region Fields

    private readonly ContentDbContext _context;

    #endregion

    #region Ctor

    public ContentRowVersionController(ContentDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await _context.ContentRowVersion.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return NotFound();

        var response = new GetContentRowVersionResponse
        {
            Id = entity.Id,
            Title = entity.Title,
            Text = entity.Text,
            Html = entity.Html
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateContentRowVersionRequest request)
    {
        var entity = new Entities.ContentRowVersion
        {
            Title = request.Title,
            Text = request.Text,
            Html = request.Html
        };

        await _context.ContentRowVersion.AddAsync(entity);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateContentRowVersionRequest request)
    {
        var entity = await _context.ContentRowVersion.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return NotFound();

        entity.Title = request.Title;
        entity.Text = request.Text;
        entity.Html = request.Html;

        _context.ContentRowVersion.Update(entity);

        await _context.SaveChangesAsync();

        return Ok();
    }

    #endregion
}
