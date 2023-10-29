using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types.InputType;

public class AddCustomerInputType : InputObjectType<Customer>
{
    protected override void Configure(IInputObjectTypeDescriptor<Customer> descriptor)
    {
        descriptor.Name("AddCustomerInput");

        descriptor.Ignore(_ => _.Id);
        descriptor.Ignore(_ => _.Purchases);

        descriptor.Field(static _ => _.Name)
            .Type<StringType>();

        descriptor.Field(static _ => _.Email)
            .Type<StringType>();
    }
}