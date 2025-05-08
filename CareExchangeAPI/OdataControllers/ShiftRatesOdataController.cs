using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/ShiftRates")]
[Tags("ShiftRates")]
[ApiController]
[ODataAttributeRouting]
public class ShiftRatesOdataController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<ShiftRate> Get()
    {
        return context.ShiftRates.AsNoTracking();
    }
}

