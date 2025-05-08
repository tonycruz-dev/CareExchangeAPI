
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobTypesController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobType>>> Get()
    {
        return await _context.JobTypes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobType>> GetById(int id)
    {
        var jobType = await _context.JobTypes.FindAsync(id);
        if (jobType == null)
            return NotFound();

        return jobType;
    }

    [HttpPost]
    public async Task<ActionResult<JobType>> Create(JobType jobType)
    {
        _context.JobTypes.Add(jobType);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = jobType.Id }, jobType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, JobType jobType)
    {
        if (id != jobType.Id)
            return BadRequest("ID mismatch");

        _context.Entry(jobType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.JobTypes.Any(j => j.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var jobType = await _context.JobTypes.FindAsync(id);
        if (jobType == null)
            return NotFound();

        _context.JobTypes.Remove(jobType);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
