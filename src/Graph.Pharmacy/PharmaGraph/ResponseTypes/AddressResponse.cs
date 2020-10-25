namespace Graph.Pharmacy.PharmaGraph.ResponseTypes
{
    using Graph.Pharmacy.Models;
    using Graph.Pharmacy.PharmaGraph.Schemas;
    using GraphQL.Types;
    using System;

    public class AddressResponse : ResponseType<AddressModel>,IGraphType
    {
        public AddressResponse()
        {
           
            Field<ObjectGraphType<Address>>("address");
            Field<ListGraphType<Link>>("links");
            IsTypeOf = xxxxxxx;
        }

        private bool xxxxxxx(object arg)
        {
            return true;
        }
    }
}