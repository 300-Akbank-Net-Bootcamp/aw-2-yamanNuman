using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly VbDbContext dbContext;

    public ContactController(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<List<Contact>> Get()
    {
        return await dbContext.Set<Contact>().ToListAsync();
    }
        
    [HttpGet("{id}")]
    public async Task<Contact> Get(int id)
    {
        var customer = await dbContext.Set<Contact>()
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        return customer;
    }
}