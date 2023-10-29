using System.ComponentModel.DataAnnotations;

namespace Sirius.GymGraphQL.Model;

public class Customer
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Purchase>? Purchases { get; set; }
}