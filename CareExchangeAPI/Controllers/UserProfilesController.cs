
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfilesController(AppDbContext dbContext) : ControllerBase
{
    private readonly AppDbContext _context = dbContext;

    // POST: api/UserProfiles
    [HttpPost]
    public async Task<IActionResult> CreateUserProfile([FromBody] UserProfile profile)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.UserProfiles.Add(profile);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUserProfile), new { id = profile.Id }, profile);
    }

    // GET: api/UserProfiles/5 (used by CreatedAtAction above)
    [HttpGet("{id}")]
    public async Task<ActionResult<UserProfile>> GetUserProfile(int id)
    {
        var profile = await _context.UserProfiles.FindAsync(id);

        if (profile == null)
            return NotFound();

        return profile;
    }

    // PUT: api/UserProfiles/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserProfile(int id, [FromBody] UserProfile profile)
    {
        if (id != profile.Id)
            return BadRequest("ID mismatch.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Entry(profile).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserProfileExists(id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/UserProfiles/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserProfile(int id)
    {
        var profile = await _context.UserProfiles.FindAsync(id);
        if (profile == null)
            return NotFound();

        _context.UserProfiles.Remove(profile);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserProfileExists(int id)
    {
        return _context.UserProfiles.Any(e => e.Id == id);
    }
}
