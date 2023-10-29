using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types.InputType;

public class UpdateCustomerInputType : InputObjectType<Customer>
{
    protected override void Configure(IInputObjectTypeDescriptor<Customer> descriptor)
    {
        descriptor.Name("UpdateCustomerInput");

        descriptor.Ignore(_ => _.Purchases);

        descriptor.Field(static _ => _.Id)
            .Type<UuidType>();
        descriptor.Field(static _ => _.Email)
            .Type<StringType>();
        descriptor.Field(static _ => _.Name)
            .Type<StringType>();
    }
}