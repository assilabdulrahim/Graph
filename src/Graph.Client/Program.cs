namespace Graph.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;

    internal partial class Program
    {

        private static void Main(string[] args)
        {
            var query = new Dictionary<string, string>() { { "query", "query{medicine{name}}" } };

            using var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonSerializer.Serialize(query));
            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/json");
            var result = httpClient.PostAsync("https://localhost:44367/api/graphql", content).GetAwaiter().GetResult();
            var jsonResult = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine(jsonResult);
            var @obj = JsonSerializer.Deserialize<Medicine>(jsonResult);
            Console.WriteLine("Hello World!");
        }
    }
}