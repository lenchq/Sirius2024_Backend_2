using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Interfaces;

public interface ITrainingRepository
{
    public Task<Training> AddTrainingAsync(Training training);
    public Task<Training> RemoveTrainingAsync(Guid id);
    public Task<Training> UpdateTrainingAsync(Training training);
    public Task<Training?> GetTrainingByIdAsync(Guid id);
    public Task<IEnumerable<Training>> GetAllTrainings();
}