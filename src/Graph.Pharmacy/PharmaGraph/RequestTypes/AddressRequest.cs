
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graph.Pharmacy.PharmaGraph.RequestTypes
{using Graph.Pharmacy.Models;
    using GraphQL.Types;

    public class AddressRequest:RequestType<AddressModel>
    {
        public AddressRequest()
        {
            Name = "AddressRequest";
            Field<StringGraphType>("city");
            Field<StringGraphType>("street1");
            Field<StringGraphType>("street2");
            Field<StringGraphType>("state");
            Field<StringGraphType>("zip");
        }
    }
}
