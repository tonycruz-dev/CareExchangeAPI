using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.OdataControllers;

[Route("odata/CandidateDocuments")]
[Tags("CandidateDocuments")]
[ApiController]
[ODataAttributeRouting]
public class CandidateDocumentsOdataController(AppDbContext context) : ControllerBase
{
    // GET: odata/CandidateDocuments
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<CandidateDocument> Get()
    {
        return context.CandidateDocuments.AsNoTracking(); 
    }
}
