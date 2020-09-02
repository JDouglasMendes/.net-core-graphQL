using Codeizi.DI.Helper.Anotations;
using GraphQL.API.Context;
using GraphQL.API.GraphQL.Types;
using GraphQL.Types;
using System.Linq;

namespace GraphQL.API.GraphQL.Queries
{
    [Injectable]
    public class EmpresaQuery : ObjectGraphType<object>
    {
        public EmpresaQuery(GraphQLContext context)
        {
            Field<ListGraphType<EmployeeType>>("funcionario",
                arguments: new QueryArguments(new QueryArgument[]{
                    new QueryArgument<StringGraphType>{Name="nome"}
                }),
                resolve: contexto =>
                {                    
                    var nome = contexto.GetArgument<string>("nome");

                    return context.
                        Funcionario.
                        Where(x => x.Name.Contains(nome)).
                        ToList();
                });

            Field<ListGraphType<RoleType>>("cargo",
                    resolve: contexto =>
                    {
                        return context.
                            Cargos.
                            ToList();
                    });
        }
    }
}