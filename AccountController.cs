using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly VbDbContext dbContext;

    public AccountController(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<List<Account>> Get()
    {
        return await dbContext.Set<Account>().ToListAsync();
    }
        
    [HttpGet("{id}")]
    public async Task<Account> Get(int id)
    {
        var customer = await dbContext.Set<Account>()
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        return customer;
    }
}