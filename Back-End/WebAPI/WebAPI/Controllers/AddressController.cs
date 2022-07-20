using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AddressController : Controller
  {
    private readonly ContactDbContext addressContext;

    public AddressController(ContactDbContext addressContext)
    {
      this.addressContext = addressContext;
    }


    // Get Address

    [HttpGet]
    [Route("{AddressID:guid}")]
    [ActionName("GetAddress")]
    public async Task<IActionResult> GetAddress([FromRoute] Guid addressID)
    {
      var address = await addressContext.Addresses.FirstOrDefaultAsync(x => x.AddressID == addressID);
      if (address != null)
      {
        return Ok(address);
      }
      return NotFound("Address Not found");
    }

    // Update Address

    [HttpPut]
    [Route("{AddressID:guid}")]
    public async Task<IActionResult> UpdateAddress([FromRoute] Guid addressID, [FromBody] Address address)
    {
      var existingAddress = await addressContext.Addresses.FirstOrDefaultAsync(x => x.AddressID == addressID);
      if (existingAddress != null)
      {
        existingAddress.Street = address.Street;
        existingAddress.City = address.City;
        existingAddress.State = address.State;
        existingAddress.ZIP = address.ZIP;

        await addressContext.SaveChangesAsync();
        return Ok(existingAddress);
      }
      return NotFound("Address Not Found");
  }   
  }
}
