using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types.InputType;

public class AddGymInputType : InputObjectType<Gym>
{
    protected override void Configure(IInputObjectTypeDescriptor<Gym> descriptor)
    {
        descriptor.Name("AddGymInput");

        descriptor.Ignore(_ => _.Id);
        descriptor.Ignore(_ => _.Trainings);
        descriptor.Ignore(_ => _.AvailableTrainings);

        descriptor.Field(static _ => _.Name)
            .Type<StringType>();

        descriptor.Field(static _ => _.ManagerName)
            .Type<StringType>();

        descriptor.Field(static _ => _.ManagerPhoneNumber)
            .Type<StringType>();
    }
}