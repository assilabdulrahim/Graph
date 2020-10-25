namespace Graph.Pharmacy.PharmaGraph.Schemas
{
    using Graph.Pharmacy.Models;
    using GraphQL.Types;

    public class Patient : Pharma<PatientModel>
    {
        public Patient()
        {
            Field<StringGraphType>("name");
            Field<IntGraphType>("age");
            Field<DateGraphType>("dob");
            Field<ListGraphType<Address>>("addresses");
            Field<ListGraphType<Prescription>>("perscription");
        }
    }
}