namespace Graph.Pharmacy.PharmaGraph.RequestTypes
{
    using GraphQL.Types;

    public abstract class RequestType<T> : InputObjectGraphType
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
    }
}