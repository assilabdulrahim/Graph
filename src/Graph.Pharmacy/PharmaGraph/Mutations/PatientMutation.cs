namespace Graph.Pharmacy.PharmaGraph.Mutations
{
    using Graph.Pharmacy.Models;
    using Graph.Pharmacy.PharmaGraph.Schemas;
    using GraphQL;
    using GraphQL.Types;

    public class PatientMutation : ObjectGraphType
    {
        public PatientMutation()
        {
            Field<Patient>(
                    "AddPatient",
                    arguments: new QueryArguments(
                      new QueryArgument<Patient> { Name = "patient" }
                    ),
                    resolve: context =>
                    {
                        var newPatient = context.GetArgument<PatientModel>("patient");
                        return AddPatient(newPatient);
                    }
                  );
        }

        private PatientModel AddPatient(PatientModel newPatient)
        {
            //it better returns all Query to the new resource.
            return newPatient;
        }
    }
}