namespace Graph.Pharmacy.PharmaGraph.Schemas
{
    using Graph.Pharmacy.Models;
    using GraphQL.Types;

    public class Address :Pharma<AddressModel>
    {
        public Address()
        {
            Field<StringGraphType>("city");
            Field<StringGraphType>("street1");
            Field<StringGraphType>("street2");
            Field<StringGraphType>("state");
            Field<StringGraphType>("zip");

            Metadata["rule"] = "rule1";
        }
    }
}