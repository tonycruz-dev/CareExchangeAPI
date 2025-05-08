using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/UserProfiles")]
[Tags("UserProfiles")]
[ApiController]
[ODataAttributeRouting]
public class UserProfilesOdataController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<UserProfile> Get()
    {
        return context.UserProfiles
                      .AsNoTracking(); 
    }
}
[Route("odata/Shifts")]
[Tags("Shifts")]
[ApiController]
[ODataAttributeRouting]
public class ShiftsOdataController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<Shift> Get()
    {
        return context.Shifts.AsNoTracking(); 
    }
}
