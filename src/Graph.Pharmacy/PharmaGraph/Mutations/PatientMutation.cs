namespace Graph.Pharmacy.PharmaGraph.Mutations
{
    using Graph.Pharmacy.Models;
    using Graph.Pharmacy.PharmaGraph.Schemas;
    using GraphQL;
    using GraphQL.Types;
    using System;

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
            Field<IntGraphType>(
                  "AddMedicine",
                  arguments: new QueryArguments(
                    new QueryArgument<Medicine> { Name = "newMed" }
                  ),
                  resolve: context =>
                  {
                      var newMed = context.GetArgument<MedicineModel>("newMed");
                      return AddMedicine(newMed);
                  }
                );
        }

        private int AddMedicine(MedicineModel newMed)
        {
            return 201;
        }

        private PatientModel AddPatient(PatientModel newPatient)
        {
            //it better returns all Query to the new resource.
            return newPatient;
        }
    }
}