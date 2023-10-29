using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types;

public class TrainingType : ObjectType<Training>
{
    protected override void Configure(IObjectTypeDescriptor<Training> descriptor)
    {
        descriptor.Name("Training");

        descriptor.Ignore(_ => _.GymId);

        descriptor.Field(static _ => _.Id)
            .Type<UuidType>();

        descriptor.Field(static _ => _.TrainingKind)
            .Type<EnumType<TrainingKind>>();

        descriptor.Field(static _ => _.Gym)
            .Type<GymType>();
        
        descriptor.Field(static _ => _.Price)
            .Type<FloatType>();
        
        descriptor.Field(static _ => _.Name)
            .Type<StringType>();
    }
}