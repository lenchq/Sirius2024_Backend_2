using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sirius.GymGraphQL.Model;

[Index(nameof(GymId))]
public class Training
{
    [Key]
    public Guid Id { get; set; }
    public TrainingKind TrainingKind { get; set; }
    public Guid GymId { get; set; }
    [ForeignKey(nameof(GymId))]
    
    public string Name { get; set; }
    
    public float Price { get; set; }
    public virtual Gym Gym { get; set; }
}

public enum TrainingKind
{
    INDIVIDUAL,
    GROUP,
    COACH,
}