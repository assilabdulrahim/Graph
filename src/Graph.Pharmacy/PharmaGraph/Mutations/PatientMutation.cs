namespace Graph.Pharmacy.PharmaGraph.Mutations
{
    using Graph.Pharmacy.Models;
    using Graph.Pharmacy.PharmaGraph.RequestTypes;
    using Graph.Pharmacy.PharmaGraph.ResponseTypes;
    using Graph.Pharmacy.PharmaGraph.Schemas;
    using GraphQL;
    using GraphQL.Types;
    using System;
    using System.Collections.Generic;

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
            Field<AddressResponse>(
                 "AddAddress",
                 arguments: new QueryArguments(
                   new QueryArgument<AddressRequest> { Name = "newAddress" }
                 ),
                 resolve: context =>
                 {
                     var newAddress = context.GetArgument<AddressModel>("newAddress");
                     return AddAddress(newAddress);
                 }
               );
        }

        private AddressResponse AddAddress(AddressModel newAddress)
        {
            string query = @"{\""query\"":\""query { address{ city, state} }\"", \""QueryType\"":\""patientQuery\""}";
            var links = new List<LinkModel>(new[] { new LinkModel { Name= "Created", Query= query } });
            return new AddressResponse
            {
             Links= links
            };
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