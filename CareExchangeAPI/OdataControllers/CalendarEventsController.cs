using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/CalendarEvents")]
[Tags("CalendarEvents")]
[ApiController]
[ODataAttributeRouting]
public class CalendarEventsController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<CalendarEvent> Get()
    {
        return context.CalendarEvents.AsNoTracking(); 
    }
}
