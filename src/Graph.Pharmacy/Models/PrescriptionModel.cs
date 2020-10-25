namespace Graph.Pharmacy.Models
{
    using System;
    using System.Collections.Generic;

    public class PrescriptionModel
    {
        public DateTime Date { get; set; }
        public IEnumerable<MedicineModel> Medication { get; set; }
        public PhysicianModel Physician { get; set; }
        public string Text { get; set; }
    }
}