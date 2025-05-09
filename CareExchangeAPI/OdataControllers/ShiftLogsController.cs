using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/ShiftLogs")]
[Tags("ShiftLogs")]
[ApiController]
[ODataAttributeRouting]
public class ShiftLogsController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<ShiftLog> Get()
    {
        return context.ShiftLogs.AsNoTracking(); 
    }
}
