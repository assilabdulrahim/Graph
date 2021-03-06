﻿namespace Graph.Pharmacy.PharmaGraph.Schemas
{
    using Graph.Pharmacy.Models;
    using GraphQL.Types;

    public abstract class Pharma<T> : ObjectGraphType<T>, IInputObjectGraphType
        where T : Model
    {
    }
}