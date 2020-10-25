namespace Graph.Pharmacy.Controllers
{
    using Graph.Pharmacy.PharmaGraph;
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

            //var inputs = query.Variables.Value;
            var schema = new Schema();
            //if (query.QueryType == "droidQuery")
            //{
            //    schema.Query = new DroidQuery();
            //}
            //else
            //{
            //    schema.Query = new WeatherForcastQuery();
            //}

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