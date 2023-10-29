using Microsoft.EntityFrameworkCore;

namespace Sirius.GymGraphQL.Types;

public class QueryType : ObjectType<Query.Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query.Query> descriptor)
    {
        descriptor.Name("Query");

        descriptor.Field(static _ => _.PurchaseById(default!, default!))
            .Argument("id", arg => arg.Type<UuidType>())
            .Type<PurchaseType>();
        descriptor.Field(static _ => _.Purchases(default!, default!))
            .Type<ListType<PurchaseType>>();
        
        descriptor.Field(static _ => _.GymById(default!, default!))
            .Argument("id", arg => arg.Type<UuidType>())
            .Type<GymType>();
        descriptor.Field(static _ => _.Gyms(default!))
            .Type<ListType<GymType>>();
        
        descriptor.Field(static _ => _.TrainingById(default!, default!))
            .Argument("id", arg => arg.Type<UuidType>())
            .Type<TrainingType>();
        descriptor.Field(static _ => _.Trainings(default!))
            .Type<ListType<TrainingType>>();
        
        descriptor.Field(static _ => _.CustomerById(default!, default!))
            .Argument("id", arg => arg.Type<UuidType>())
            .Type<CustomerType>();
        descriptor.Field(static _ => _.Customers(default!))
            .Type<ListType<CustomerType>>();
        
        
    }
}