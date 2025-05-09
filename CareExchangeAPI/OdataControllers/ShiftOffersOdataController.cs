using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/ShiftOffers")]
[Tags("ShiftOffers")]
[ApiController]
[ODataAttributeRouting]
public class ShiftOffersOdataController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<ShiftOffer> Get()
    {
        return context.ShiftOffers
                      .AsNoTracking(); 
    }
}

