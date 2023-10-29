using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types.InputType;

public class UpdateGymInputType : InputObjectType<Gym>
{
    protected override void Configure(IInputObjectTypeDescriptor<Gym> descriptor)
    {
        descriptor.Name("UpdateGymInput");

        descriptor.Ignore(_ => _.AvailableTrainings); 
        descriptor.Ignore(_ => _.Trainings); 

        descriptor.Field(static _ => _.Id)
            .Type<UuidType>();
        descriptor.Field(static _ => _.ManagerPhoneNumber)
            .Type<StringType>();
        descriptor.Field(static _ => _.ManagerName)
            .Type<StringType>();
        descriptor.Field(static _ => _.Name)
            .Type<StringType>();
    }
}