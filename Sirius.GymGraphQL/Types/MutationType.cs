using Sirius.GymGraphQL.Types.InputType;

namespace Sirius.GymGraphQL.Types;

public class MutationType : ObjectType<Mutation.Mutation>
{
    protected override void Configure(IObjectTypeDescriptor<Mutation.Mutation> descriptor)
    {
        // CUSTOMER -----------------
        descriptor.Field(_ => _.AddCustomerAsync(default!, default!))
            // .Name("addCustomer")
            .Argument("input", _ => _.Type<AddCustomerInputType>())
            .Type<CustomerType>()
            .UseMutationConvention();
        descriptor.Field(static _ => _.UpdateCustomerAsync(default!, default!))
            // .Name("updateCustomer")
            .Argument("input", static _ => _.Type<UpdateCustomerInputType>())
            .Type<CustomerType>();
        descriptor.Field(static _ => _.DeleteCustomerAsync(default!, default!));

        // GYM -------------------------
        descriptor.Field(_ => _.AddGymAsync(default!, default!))
            .Argument("input", _ => _.Type<AddGymInputType>())
            .Type<GymType>()
            .UseMutationConvention();
        descriptor.Field(static _ => _.UpdateGymAsync(default!, default!))
            .Argument("input", static _ => _.Type<UpdateGymInputType>())
            .Type<GymType>();
        descriptor.Field(static _ => _.DeleteGymAsync(default!, default!));
        //  Training ----------------------------
        descriptor.Field(_ => _.AddTrainingAsync(default!, default!, default!))
            .Argument("input", _ => _.Type<AddTrainingInputType>())
            .Type<TrainingType>()
            .UseMutationConvention();
        descriptor.Field(static _ => _.UpdateTrainingAsync(default!, default!))
            .Argument("input", static _ => _.Type<UpdateTrainingInputType>())
            .Type<TrainingType>();
        descriptor.Field(static _ => _.DeleteTrainingAsync(default!, default!));
        // Purchase
        descriptor.Field(_ => _.PurchaseTraining(default!, default!, default!, default!))
            .Argument("input", _ => _.Type<PurchaseTrainingInputType>())
            .Type<PurchaseType>()
            .UseMutationConvention();
        // No need for updating Purchases
        // descriptor.Field(static _ => _.UpdatePurchaseAsync(default!, default!))
        //     .Argument("input", static _ => _.Type<UpdatePurchaseInputType>())
        //     .Type<PurchaseType>();
        descriptor.Field(static _ => _.DeletePurchaseAsync(default!, default!));
    }
}