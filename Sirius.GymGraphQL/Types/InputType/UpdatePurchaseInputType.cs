using Sirius.GymGraphQL.Model;

namespace Sirius.GymGraphQL.Types.InputType;

public class UpdatePurchaseInputType : InputObjectType<Purchase>
{
    // There is no need for updating Purchases
    
    // protected override void Configure(IInputObjectTypeDescriptor<Purchase> descriptor)
    // {
    //     descriptor.Name("UpdatePurchaseInput");
    //
    //     descriptor.Ignore(_ => _.Training);
    //     descriptor.Ignore(_ => _.Customer);
    //     descriptor.Ignore(_ => _.CustomerId);
    //     descriptor.Ignore(_ => _.TrainingId);
    //
    //     descriptor.Field(static _ => _.Id)
    //         .Type<UuidType>();
    //     descriptor.Field(static _ => _.TrainingKind)
    //         .Type<EnumType<TrainingKind>>();
    //     descriptor.Field(static _ => _.Price)
    //         .Type<FloatType>();
    //     descriptor.Field(static _ => _.Name)
    //         .Type<StringType>();
    // }
}