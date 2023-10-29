using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types.InputType;

public class UpdateTrainingInputType : InputObjectType<Training>
{
    protected override void Configure(IInputObjectTypeDescriptor<Training> descriptor)
    {
        descriptor.Name("UpdateTrainingInput");

        descriptor.Ignore(_ => _.Gym);
        descriptor.Ignore(_ => _.GymId);

        descriptor.Field(static _ => _.Id)
            .Type<UuidType>();
        descriptor.Field(static _ => _.TrainingKind)
            .Type<EnumType<TrainingKind>>();
        descriptor.Field(static _ => _.Price)
            .Type<FloatType>();
        descriptor.Field(static _ => _.Name)
            .Type<StringType>();
    }
}