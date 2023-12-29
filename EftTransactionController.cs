using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EftTransactionController : ControllerBase
{
    private readonly VbDbContext dbContext;

    public EftTransactionController(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<List<EftTransaction>> Get()
    {
        return await dbContext.Set<EftTransaction>().ToListAsync();
    }
        
    [HttpGet("{id}")]
    public async Task<EftTransaction> Get(int id)
    {
        var customer = await dbContext.Set<EftTransaction>()
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        return customer;
    }
}