using GraphQL.API.Context;
using GraphQL.API.GraphQL.Types;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GraphQL.API.GraphQL.Queries
{
    public class EmpresaQuery : ObjectGraphType<object>
    {
        public EmpresaQuery(GraphQLContext context)
        {
            Field<ListGraphType<FuncionarioType>>("funcionario",
                arguments: new QueryArguments(new QueryArgument[]{
                    new QueryArgument<StringGraphType>{Name="nome"}
                }),
                resolve: contexto =>
                {
                    var nome = contexto.GetArgument<string>("nome");
                    
                    return context.
                        Funcionario.
                        Where(x => x.Nome.Contains(nome)).
                        ToList();
                });

            Field<ListGraphType<CargoType>>("cargo",
                    resolve: contexto =>
                    {
                        return context.
                            Cargos.
                            ToList();
                    });
        }
    }
}