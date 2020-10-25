namespace Graph.Pharmacy.PharmaGraph.Queries
{
    using Graph.Pharmacy.Models;
    using Graph.Pharmacy.PharmaGraph.Schemas;
    using GraphQL.Types;
    using System;

    public class PatientQuery : ObjectGraphType
    {
        public PatientQuery()
        {
            Field<Patient>(
                   "patient",
                   arguments: null,
                   resolve: context =>
                   {
                       return GetPatient(null);
                   }
                 );
            Field<Medicine>(
                   "medicine",
                   arguments: null,
                   resolve: context =>
                   {
                       return GetMedicine(null);
                   }
                 );
            Field<Address>(
                  "address",
                  arguments: null,
                  resolve: context =>
                  {
                      return GetAddress(null);
                  }
                );
        }

        private AddressModel GetAddress(object p)
        {
            return new AddressModel { City = "I dont know", State = "either" };
        }

        private MedicineModel GetMedicine(object p)
        {
            return new MedicineModel { Dose = 12, Name = "Vitamin A" };
        }

        private PatientModel GetPatient(string v)
        {
            return new PatientModel
            {
                Name = "John Doe",
                DOB = new System.DateTime(1970, 5, 7),
                Addresses = new[] {
                new AddressModel { City = "Rogers", State = "AR", Street1 = "Dixieland", Zip = "72756" },
                new AddressModel { City = "Bentonville", State = "AR", Street1 = "Avenue", Zip = "72712" },
                new AddressModel { City = "Bentonville", State = "AR", Street1 = "Steet A", Zip = "72711" }
                },
                Prescriptions = new[] {
                 new PrescriptionModel{ Date = new System.DateTime(2000,2,2), Medication= new []{ new MedicineModel { Name = "Med1", Dose= 20 } } , Physician = new PhysicianModel{ Name= "Dr. A" }, Text = "Prescription 1" },
                 new PrescriptionModel{ Date = new System.DateTime(2001,3,3), Medication= null , Physician = new PhysicianModel{ Name= "Dr. B" }, Text = "Prescription 2" }
                }
            };
        }
    }
}