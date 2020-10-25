

namespace Graph.Pharmacy.PharmaGraph.RequestTypes
{
    using GraphQL.Types;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public abstract class RequestType<T> : InputObjectGraphType
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;

    }
}
