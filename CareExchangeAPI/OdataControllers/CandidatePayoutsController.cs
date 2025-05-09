using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/CandidatePayouts")]
[Tags("CandidatePayouts")]
[ApiController]
[ODataAttributeRouting]
public class CandidatePayoutsController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<CandidatePayout> Get()
    {
        return context.CandidatePayouts.AsNoTracking(); 
    }
}
