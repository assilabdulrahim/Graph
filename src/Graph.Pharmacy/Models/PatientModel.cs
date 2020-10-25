namespace Graph.Pharmacy.Models
{
    using System;
    using System.Collections.Generic;

    public class PatientModel : Model
    {
        public IEnumerable<AddressModel> Addresses { get; set; }
        public int Age => DateTime.Now.Year - DOB.Year;
        public DateTime DOB { get; set; }
        public string Name { get; set; }
        public IEnumerable<PrescriptionModel> Prescriptions { get; set; }
    }
}