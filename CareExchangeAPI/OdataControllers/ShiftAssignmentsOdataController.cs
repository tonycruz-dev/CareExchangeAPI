using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/ShiftAssignments")]
[Tags("ShiftAssignments")]
[ApiController]
[ODataAttributeRouting]
public class ShiftAssignmentsOdataController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<ShiftAssignment> Get()
    {
        return context.ShiftAssignments
                      .AsNoTracking(); 
    }
}

