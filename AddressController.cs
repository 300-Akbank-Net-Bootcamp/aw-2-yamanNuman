using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly VbDbContext dbContext;

    public AddressController(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<List<Address>> Get()
    {
        return await dbContext.Set<Address>().ToListAsync();
    }
        
    [HttpGet("{id}")]
    public async Task<Address> Get(int id)
    {
        var customer = await dbContext.Set<Address>()
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        return customer;
    }
}