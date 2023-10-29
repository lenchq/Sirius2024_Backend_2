using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Interfaces;

public interface IGymRepository
{
    public Task<Gym> AddGymAsync(Gym gym);
    public Task<Gym> RemoveGymAsync(Guid id);
    public Task<Gym> UpdateGymAsync(Gym gym);
    public Task<Gym?> GetGymByIdAsync(Guid id);
    public Task<IEnumerable<Gym>> GetAllGyms();

    public Task<int> GetAvailableTrainingsCount(Guid id);
}
