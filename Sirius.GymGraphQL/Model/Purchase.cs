using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sirius.GymGraphQL.Model;

[Index(nameof(TrainingId))]
[Index(nameof(CustomerId))]
public class Purchase
{
    [Key]
    public Guid Id { get; set; }
    
    public Guid TrainingId { get; set; }
    public Guid CustomerId { get; set; }
    
    [ForeignKey(nameof(TrainingId))]
    public virtual Training? Training { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public virtual Customer? Customer { get; set; }

    public float Price { get; set; }
    public float Income { get; set; }
}