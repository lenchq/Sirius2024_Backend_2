using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types;

public class CustomerType : ObjectType<Customer>
{
    protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
    {
        descriptor.Name("Customer");

        descriptor.Field(static _ => _.Id)
            .Type<UuidType>()
            .Name("id");
        
        descriptor.Field(static _ => _.Name)
            .Type<StringType>()
            .Name("name");
        
        descriptor.Field(static _ => _.Email)
            .Type<StringType>()
            .Name("email");
        
        descriptor.Field(static _ => _.Purchases)
            .Type<ListType<PurchaseType>>()
            .Name("purchases");
    }

    private class Resolvers
    {
        
    }
}