using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/CareHomeClients")]
[Tags("CareHomeClients")]
[ApiController]
[ODataAttributeRouting]
public class CareHomeClientsOdataController(AppDbContext context)
{
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<CareHomeClient> Get()
    {
        return context.CareHomeClients.AsNoTracking();
    }
}
