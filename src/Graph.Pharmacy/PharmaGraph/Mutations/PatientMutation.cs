namespace Graph.Pharmacy.PharmaGraph.Mutations
{
    using Graph.Pharmacy.Models;
    using GraphQL.Types;
    using System;

    public class PatientMutation : ObjectGraphType
    {
        public PatientMutation()
        {
            //Field<Patient>(
            //        "mutatePatient",
            //        arguments: new QueryArguments(
            //          new QueryArgument<Patient> { }
            //        ),
            //        resolve: context =>
            //        {
            //            var newPatient = context.GetArgument<PatientModel>("patient");
            //            return AddPatient(newPatient);
            //        }
            //      );
        }

        private PatientModel AddPatient(PatientModel newPatient)
        {
            throw new NotImplementedException();
        }
    }
}