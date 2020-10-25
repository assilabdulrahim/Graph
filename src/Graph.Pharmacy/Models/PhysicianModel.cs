namespace Graph.Pharmacy.Models
{
    using System.Collections.Generic;

    public class PhysicianModel
    {
        public IEnumerable<AddressModel> Addresses { get; set; }
        public string Name { get; set; }
        public IEnumerable<PrescriptionModel> Prescriptions { get; set; }
        public IEnumerable<PatientModel> Patients { get; set; }
    }
}