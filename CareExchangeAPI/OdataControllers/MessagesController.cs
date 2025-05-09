using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/Messages")]
[Tags("Messages")]
[ApiController]
[ODataAttributeRouting]
public class MessagesController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<Message> Get()
    {
        return context.Messages.AsNoTracking(); 
    }
}
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
