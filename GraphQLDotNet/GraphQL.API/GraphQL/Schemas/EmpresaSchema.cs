using Codeizi.DI.Helper.Anotations;
using GraphQL.API.GraphQL.Mutations;
using GraphQL.API.GraphQL.Queries;
using GraphQL.Types;

namespace GraphQL.API.GraphQL.Schemas
{
    [Injectable]
    public class EmpresaSchema : Schema
    {
        public EmpresaSchema(IDependencyResolver dependencyResolver)
            : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<EmpresaQuery>();
            Mutation = dependencyResolver.Resolve<CompanyMutation>();            
        }
    }
}