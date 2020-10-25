namespace Graph.Pharmacy.PharmaGraph.Schemas
{
    using Graph.Pharmacy.Models;
    using GraphQL.Types;

    public class Physician : Pharma<PhysicianModel>
    {
        public Physician()
        {
            Field<StringGraphType>("name");
            Field<ListGraphType<Address>>("addresses");
            Field<ListGraphType<Prescription>>("perscription");
            Field<ListGraphType<Patient>>("patients");
        }
    }
}