namespace Graph.Pharmacy.PharmaGraph.Middleware
{
    using GraphQL;
    using GraphQL.Instrumentation;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class LoggingMiddleware : IFieldMiddleware
    {
        private readonly ILogger Logger;

        public LoggingMiddleware(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger<LoggingMiddleware>();
        }

        public async Task<object> Resolve(IResolveFieldContext context, FieldMiddlewareDelegate next)
        {
            string message = $"FieldName: {context.FieldName}, Operation: {context.Operation}";
            Logger.LogDebug(message);
            return await next(context);
        }
    }
}