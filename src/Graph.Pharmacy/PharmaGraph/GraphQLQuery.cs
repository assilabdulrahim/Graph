namespace Graph.Pharmacy.PharmaGraph
{
    using Newtonsoft.Json.Linq;

    public class GraphQLQuery
    {
        public string NamedQuery { get; set; }
        public string OperationName { get; set; }
        public string Query { get; set; }
        public string QueryType { get; set; }
        public JObject Variables { get; set; }
    }
}