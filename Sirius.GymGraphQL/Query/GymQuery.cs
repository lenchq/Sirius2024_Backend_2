using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Query;

public partial class Query
{
    public async Task<Gym[]> Gyms([Service] IGymRepository repo)
    {
        return (await repo.GetAllGyms()).ToArray();
    }
    public async Task<Gym> GymById(Guid id, [Service] IGymRepository repo)
    {
        return await repo.GetGymByIdAsync(id) ?? throw new GraphQLException("Gym with this id not found");
    }
}