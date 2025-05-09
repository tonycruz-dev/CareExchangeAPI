using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/Documents")]
[Tags("Documents")]
[ApiController]
[ODataAttributeRouting]
public class DocumentsOdataController(AppDbContext context) : ControllerBase
{
    // GET: odata/UserProfiles
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<Document> Get()
    {
        return context.Documents.AsNoTracking(); 
    }
}
