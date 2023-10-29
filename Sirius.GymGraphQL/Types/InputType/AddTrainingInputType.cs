using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types.InputType;

public class AddTrainingInputType : InputObjectType<Training>
{
    protected override void Configure(IInputObjectTypeDescriptor<Training> descriptor)
    {
        descriptor.Name("AddTrainingInput");

        descriptor.Ignore(_ => _.Gym);
        descriptor.Ignore(_ => _.Id);

        descriptor.Field(static _ => _.GymId)
            .Type<NonNullType<UuidType>>();

        descriptor.Field(static _ => _.Name)
            .Type<NonNullType<StringType>>();

        descriptor.Field(static _ => _.Price)
            .Type<NonNullType<FloatType>>();
    }
}