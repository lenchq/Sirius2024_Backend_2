using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types.InputType;

public class PurchaseTrainingInputType : InputObjectType<Purchase>
{
    protected override void Configure(IInputObjectTypeDescriptor<Purchase> descriptor)
    {
        descriptor.Name("PurchaseTraining");

        descriptor.Ignore(_ => _.Customer);
        descriptor.Ignore(_ => _.Training);
        descriptor.Ignore(_ => _.Id);
        descriptor.Ignore(_ => _.Price);
        descriptor.Ignore(_ => _.Income);

        descriptor.Field(static _ => _.CustomerId)
            .Type<UuidType>();

        descriptor.Field(static _ => _.TrainingId)
            .Type<UuidType>();
    }
}