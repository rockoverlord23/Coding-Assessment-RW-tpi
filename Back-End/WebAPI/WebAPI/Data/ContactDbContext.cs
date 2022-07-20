using Microsoft.EntityFrameworkCore;
using WebAPI.Models;


namespace WebAPI.Data
{
  public class ContactDbContext : DbContext
  {
    public ContactDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }

  }
}
