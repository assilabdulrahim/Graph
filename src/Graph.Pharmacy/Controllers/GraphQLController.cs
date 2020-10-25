namespace Graph.Pharmacy.Controllers
{
    using Graph.Pharmacy.PharmaGraph;
    using Graph.Pharmacy.PharmaGraph.Middleware;
    using Graph.Pharmacy.PharmaGraph.Mutations;
    using Graph.Pharmacy.PharmaGraph.Queries;
    using Graph.Pharmacy.PharmaGraph.Validation.Rules;
    using GraphQL;
    using GraphQL.Instrumentation;
    using GraphQL.Types;
    using GraphQL.Validation;
    using GraphQL.Validation.Complexity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly PatientQuery PatientQuery;
        private readonly PatientMutation PatientMutation;
        private readonly ILogger Logger;
        private readonly IDocumentExecuter DocumentExecuter;
        private readonly ILoggerFactory LoggerFactory;

        public GraphQLController(PatientQuery patientQuery, PatientMutation patientMutation, IDocumentExecuter documentExecuter, ILoggerFactory loggerFactory)
        {
            this.PatientQuery = patientQuery;
            this.PatientMutation = patientMutation;
            this.DocumentExecuter = documentExecuter;
            this.LoggerFactory = loggerFactory;
            this.Logger = loggerFactory.CreateLogger<GraphQLController>();
        }

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            DateTime start = DateTime.UtcNow;

            var schema = new Schema
            {
                Query = PatientQuery,
                Mutation = PatientMutation
            };

            var result = await DocumentExecuter.ExecuteAsync(executionOptions =>
            {
                executionOptions.Schema = schema;
                executionOptions.Query = query.Query;
                executionOptions.OperationName = query.OperationName;
                executionOptions.Inputs = null;
                executionOptions.EnableMetrics = true;
                executionOptions.FieldMiddleware.Use<InstrumentFieldsMiddleware>();
                executionOptions.FieldMiddleware.Use(new LoggingMiddleware(LoggerFactory));
                executionOptions.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                executionOptions.ValidationRules = new[]
                                                {
                                                  new AuthorizationValidationRule()
                                                }
                                                .Concat(DocumentValidator.CoreRules);
            }).ConfigureAwait(false);
            result.EnrichWithApolloTracing(start);

            if (result.Errors?.Count > 0)
            {
                string errorMessage = result.Errors[0].InnerException?.ToString() ?? result.Errors[0].Message;
                Logger.LogError(errorMessage);
                return base.BadRequest(errorMessage);
            }

            return Ok(result);
        }
    }
}