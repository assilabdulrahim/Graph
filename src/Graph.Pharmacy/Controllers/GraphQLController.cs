namespace Graph.Pharmacy.Controllers
{
    using Graph.Pharmacy.PharmaGraph;
    using Graph.Pharmacy.PharmaGraph.Mutations;
    using Graph.Pharmacy.PharmaGraph.Queries;
    using GraphQL;
    using GraphQL.Instrumentation;
    using GraphQL.Types;
    using GraphQL.Validation.Complexity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            System.DateTime start = DateTime.UtcNow;

            var schema = new Schema();
            if (query.QueryType == "patientQuery")
            {
                schema.Query = new PatientQuery();
                schema.Mutation = new PatientMutation();
            }
            else
            {
                schema.Query = new PatientQuery();
                schema.Mutation = new PatientMutation();
            }

            var result = await new DocumentExecuter().ExecuteAsync(executionOptions =>
            {
                executionOptions.Schema = schema;
                executionOptions.Query = query.Query;
                executionOptions.OperationName = query.OperationName;
                executionOptions.Inputs = null;
                executionOptions.EnableMetrics = true;
                executionOptions.FieldMiddleware.Use<InstrumentFieldsMiddleware>();
                //executionOptions.FieldMiddleware.Use<LoggingMiddleware>();
                executionOptions.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                //executionOptions.ValidationRules = new[]
                //                                {
                //                                  new RequiresAuthValidationRule()
                //                                }
                //                                .Concat(DocumentValidator.CoreRules);
            }).ConfigureAwait(false);
            result.EnrichWithApolloTracing(start);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors[0].InnerException?.ToString() ?? result.Errors[0].Message);
            }

            return Ok(result);
        }
    }
}