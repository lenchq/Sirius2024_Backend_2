using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Mutation;

public partial class Mutation
{
    public async Task<Training> AddTrainingAsync(
        Training input,
        [Service] ITrainingRepository trainingRepo,
        [Service] IGymRepository gymRepo)
    {
        if (await gymRepo.GetGymByIdAsync(input.GymId) is null)
            NotFound<Gym>();
        
        var training = new Training
        {
            Id = Guid.NewGuid(),
            GymId = input.GymId,
            Name = input.Name,
            Price = input.Price,
            TrainingKind = input.TrainingKind
        };

        await trainingRepo.AddTrainingAsync(training);

        return training;
    }
    public async Task<Training> DeleteTrainingAsync(
        Guid input,
        [Service] ITrainingRepository trainingRepo)
    {
        if (await trainingRepo.GetTrainingByIdAsync(input) is null)
            NotFound<Training>();
        return await trainingRepo.RemoveTrainingAsync(input);
    }
    
    public async Task<Training> UpdateTrainingAsync(
        Training input,
        [Service] ITrainingRepository trainingRepo)
    {
        if (await trainingRepo.GetTrainingByIdAsync(input.Id) is null)
            NotFound<Training>();
        
        return await trainingRepo.UpdateTrainingAsync(input);
    }
}