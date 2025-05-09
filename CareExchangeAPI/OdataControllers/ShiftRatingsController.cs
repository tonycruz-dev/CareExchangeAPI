using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/ShiftRatings")]
[Tags("ShiftRatings")]
[ApiController]
[ODataAttributeRouting]
public class ShiftRatingsController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<ShiftRating> Get()
    {
        return context.ShiftRatings.AsNoTracking(); 
    }
}
