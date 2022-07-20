using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models;

namespace WebAPI.Models
{
  public class Contact
  {
    [Key]
    public Guid ContactId { get; set; }
    [Required]
    [StringLength(75)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(75)]
    public string LastName { get; set; }
    [Required]
    [StringLength(20)]
    public string Phone { get; set; }
    [Required]
    [StringLength(75)]
    public string Email { get; set; }

    [Required]
    [ForeignKey("Addresses")]
    public Guid AddressID { get; set; }

    public virtual Address Addresses { get; set; }

  }
}
