namespace Graph.Pharmacy.PharmaGraph.ResponseTypes
{
    using Graph.Pharmacy.Models;
    using Graph.Pharmacy.PharmaGraph.Schemas;
    using GraphQL.Types;

    public class AddressResponse : ResponseType<AddressModel>, IGraphType
    {
        public AddressResponse()
        {
            Field<ObjectGraphType<Address>>("address");
            Field<ListGraphType<Link>>("links");
            IsTypeOf = (arg) => true;
        }
    }
}