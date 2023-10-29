using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sirius.GymGraphQL.Model;

public class Gym
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ManagerName { get; set; }
    public string ManagerPhoneNumber { get; set; }
    public ICollection<Training>? Trainings { get; set; }
    
    [NotMapped]
    public int AvailableTrainings { get; set; }
}