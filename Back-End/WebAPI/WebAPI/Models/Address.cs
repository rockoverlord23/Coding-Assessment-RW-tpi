using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
  public class Address
  {
    [Key]
    public Guid AddressID { get; set; }

    [Required]
    [StringLength(75)]
    public string Street { get; set; }

    [Required]
    [StringLength(75)]
    public string City { get; set; }

    [Required]
    [StringLength(75)]
    public string State { get; set; }

    [Required]
    [StringLength(10)]
    public string ZIP { get; set; }

  }
}
