using Concurrency.API.Context;
using Concurrency.API.Models.ContentConcurrency.Request;
using Concurrency.API.Models.ContentConcurrency.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Concurrency.API.Controllers;

[Route("api/content-concurrency")]
[ApiController]
public class ContentConcurrencyController : ControllerBase
{
    #region Fields

    private readonly ContentDbContext _context;

    #endregion

    #region Ctor

    public ContentConcurrencyController(ContentDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await _context.ContentConcurrency.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return NotFound();

        var response = new GetContentConcurrencyResponse
        {
            Id = entity.Id,
            Title = entity.Title,
            Text = entity.Text,
            Html = entity.Html
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateContentConcurrencyRequest request)
    {
        var entity = new Entities.ContentConcurrency
        {
            Title = request.Title,
            Text = request.Text,
            Html = request.Html
        };

        await _context.ContentConcurrency.AddAsync(entity);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateContentConcurrencyRequest request)
    {
        var entity = await _context.ContentConcurrency.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return NotFound();

        entity.Title = request.Title;
        entity.Text = request.Text;
        entity.Html = request.Html;

        _context.ContentConcurrency.Update(entity);

        await _context.SaveChangesAsync();

        return Ok();
    }

    #endregion
}
