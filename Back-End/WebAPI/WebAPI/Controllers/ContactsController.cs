using WebAPI.Data;

using WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
  
  [ApiController]
  [Route("api/[controller]")]
  public class ContactsController : Controller
  {
    private readonly ContactDbContext contactDbContext;
    public ContactsController(ContactDbContext contactDbContext)
    {
      this.contactDbContext = contactDbContext;
    }

    //Get all Contacts

    [HttpGet]
    public async Task<IActionResult> GetAllContacts()
    {
      var contacts = await contactDbContext.Contacts.ToListAsync();
      return Ok(contacts);
    }

    //Get Single Contact

    [HttpGet]
    [Route("{ContactId:guid}")]
    [ActionName("GetContact")]
    public async Task<IActionResult> GetContact([FromRoute] Guid contactID)
    {
      var contact = await contactDbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == contactID);
      if (contact != null)
      {
        return Ok(contact);
      }
      return NotFound("Contact Not found");
    }

    // add Contact

    [HttpPost]
    public async Task<IActionResult> AddContact([FromBody] Contact contact)
    {
      
      contact.ContactId = Guid.NewGuid();
      await contactDbContext.Contacts.AddAsync(contact);
      await contactDbContext.SaveChangesAsync();

      return CreatedAtAction(nameof(GetContact), new { ContactId = contact.ContactId }, contact);
    }

    // Update Contact

    [HttpPut]
    [Route("{ContactId:guid}")]
    public async Task<IActionResult> UpdateContact([FromRoute] Guid contactID, [FromBody] Contact contact)
    {
      var existingContact = await contactDbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == contactID);
      if (existingContact != null)
      {
        existingContact.FirstName = contact.FirstName;
        existingContact.LastName = contact.LastName;
        existingContact.Phone = contact.Phone;
        existingContact.Email = contact.Email;
        await contactDbContext.SaveChangesAsync();
        return Ok(existingContact);
      }
      return NotFound("Contact Not Found");

    }

    // Delete Contact

    [HttpDelete]
    [Route("{ContactID:guid}")]
    public async Task<IActionResult> DeleteContact([FromRoute] Guid contactID)
    {
      var existingContact = await contactDbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == contactID);
      if (existingContact != null)
      {
        //await DeleteAddress(existingContact.AddressID);
        contactDbContext.Remove(existingContact);
        await contactDbContext.SaveChangesAsync();
        return Ok(existingContact);
      }
      return NotFound("Contact Not Found");
    }

    

  }
}
