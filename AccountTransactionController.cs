using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountTransactionController : ControllerBase
{
    private readonly VbDbContext dbContext;

    public AccountTransactionController(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<List<AccountTransaction>> Get()
    {
        return await dbContext.Set<AccountTransaction>().ToListAsync();
    }
        
    [HttpGet("{id}")]
    public async Task<AccountTransaction> Get(int id)
    {
        var customer = await dbContext.Set<AccountTransaction>()
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        return customer;
    }
}