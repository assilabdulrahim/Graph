namespace Graph.Pharmacy.Models
{
    public class AddressModel: Model
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Zip { get; set; }
    }
}