namespace Graph.Pharmacy.PharmaGraph.Validation.Rules
{
    using GraphQL.Validation;
    using System.Threading.Tasks;

    public class AuthorizationValidationRule : IValidationRule
    {
        //There is a good example about authorization in here
        //https://graphql-dotnet.github.io/docs/getting-started/authorization
        //I was thinking of abstract rule that all validation inherits from
        //
        public Task<INodeVisitor> ValidateAsync(ValidationContext context)
        {
            var document = context.Document;
            return Task.FromResult(new DebugNodeVisitor() as INodeVisitor);
        }
    }
}