namespace Graph.Pharmacy.PharmaGraph.Schemas
{
    using Graph.Pharmacy.Models;
    using GraphQL.Types;

    public class Medicine : Pharma<MedicineModel>
    {
        public Medicine()
        {
            Field<StringGraphType>("name");
            Field<IntGraphType>("dose");
        }
    }
}