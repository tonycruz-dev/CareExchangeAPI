using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/CandidateAvailabilities")]
[Tags("CandidateAvailabilities")]
[ApiController]
[ODataAttributeRouting]
public class CandidateAvailabilitiesOdataController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<CandidateAvailability> Get()
    {
        return context.CandidateAvailabilities.AsNoTracking(); 
    }
}
