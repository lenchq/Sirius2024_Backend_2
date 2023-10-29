using Sirius.GymGraphQL.Interfaces;
using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types;

public class GymType : ObjectType<Gym>
{
    protected override void Configure(IObjectTypeDescriptor<Gym> descriptor)
    {
        descriptor.Name("Gym");

        descriptor.Field(static _ => _.Id)
            .Type<UuidType>();
        
        descriptor.Field(static _ => _.Name)
            .Type<StringType>();

        descriptor.Field(static _ => _.ManagerPhoneNumber)
            .Type<StringType>();

        descriptor.Field(static _ => _.ManagerName)
            .Type<StringType>();
        
        descriptor.Field(static _ => _.Trainings)
            .Type<ListType<TrainingType>>();

        descriptor.Field(static _ => _.AvailableTrainings)
            .Type<IntType>()
            .ResolveWith<Resolvers>(_ => _.GetAvailableTrainingsCount(default!, default!));
    }

    private class Resolvers
    {
        public async Task<int> GetAvailableTrainingsCount([Parent] Gym gym, [Service] IGymRepository repo)
        {
            return await repo.GetAvailableTrainingsCount(gym.Id);
        }
    }
}