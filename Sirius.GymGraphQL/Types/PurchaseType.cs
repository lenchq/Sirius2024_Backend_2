using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types;

public class PurchaseType : ObjectType<Purchase>
{
    protected override void Configure(IObjectTypeDescriptor<Purchase> descriptor)
    {
        descriptor.Name("Purchase");

        descriptor.Ignore(_ => _.CustomerId);
        descriptor.Ignore(_ => _.TrainingId);

        descriptor.Field(static _ => _.Id)
            .Type<StringType>()
            .Name("id");

        descriptor.Field(static _ => _.Price)
            .Type<FloatType>();

        descriptor.Field(static _ => _.Income)
            .Type<FloatType>();

        descriptor.Field(static _ => _.Training)
            .Type<TrainingType>();

        descriptor.Field(static _ => _.Customer)
            .Type<CustomerType>();
    }

    private class Resolvers
    {
        
    }
}