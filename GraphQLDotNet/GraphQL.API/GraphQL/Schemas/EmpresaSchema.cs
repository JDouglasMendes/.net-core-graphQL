using GraphQL.API.GraphQL.Mutations;
using GraphQL.API.GraphQL.Queries;
using GraphQL.Types;

namespace GraphQL.API.GraphQL.Schemas
{
    public class EmpresaSchema : Schema
    {
        public EmpresaSchema(IDependencyResolver dependencyResolver)
            : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<EmpresaQuery>();
            Mutation = dependencyResolver.Resolve<EmpresaMutation>();
        }
    }
}