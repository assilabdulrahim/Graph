namespace Graph.Pharmacy.PharmaGraph.ResponseTypes
{
    using GraphQL.Types;

    public class Link : ResponseType<LinkModel>
    {
        public Link()
        {
            Field<StringGraphType>("name");
            Field<StringGraphType>("query");
        }
    }
}