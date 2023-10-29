using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Query;

public partial class Query
{
    public async Task<Training[]> Trainings([Service] ITrainingRepository repo)
    {
        return (await repo.GetAllTrainings()).ToArray();
    }
    public async Task<Training> TrainingById(Guid id, [Service] ITrainingRepository repo)
    {
        return await repo.GetTrainingByIdAsync(id) ?? throw new GraphQLException("Training with this id not found");
    }
}