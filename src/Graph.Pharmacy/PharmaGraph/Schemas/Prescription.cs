﻿namespace Graph.Pharmacy.PharmaGraph.Schemas
{
    using Graph.Pharmacy.Models;
    using GraphQL.Types;

    public class Prescription : Pharma<PrescriptionModel>
    {
        public Prescription()
        {
            Field<DateGraphType>("date");
            Field<StringGraphType>("text");
            Field<ObjectGraphType<Physician>>("physician");
            Field<ListGraphType<Medicine>>("medication");
        }
    }
}