namespace Graph.Pharmacy.PharmaGraph.Schemas
{
    using Graph.Pharmacy.Models;
    using GraphQL.Types;

    public class Physician : Pharma<PhysicianModel>
    {
        public Physician()
        {
            Name = "Physician";
            Field<StringGraphType>("name");
            Field<ListGraphType<Address>>("addresses");
            Field<ListGraphType<Prescription>>("prescriptions");
            Field<ListGraphType<Patient>>("patients");
        }
    }
}