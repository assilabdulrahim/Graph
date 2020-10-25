namespace Graph.Pharmacy.PharmaGraph.ResponseTypes
{
    using GraphQL.Types;
    using System.Collections.Generic;

    //This class is the base class for all the responses .
    //if you create a new resource, the query of that newly created resource should be in one line
    //if you queried a list of resources, you should get informative links about (Next, previous, total and current etc.)
    public abstract class ResponseType<T> : ObjectGraphType<T>
    {
        public IEnumerable<LinkModel> Links { get; set; } = new List<LinkModel>();
    }
}