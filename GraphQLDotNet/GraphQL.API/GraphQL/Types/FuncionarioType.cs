using GraphQL.API.Context;
using GraphQL.API.Models;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.GraphQL.Types
{
    public class FuncionarioType : ObjectGraphType<Funcionario>
    {
        public FuncionarioType(GraphQLContext context)
        {
            Name = "funcionario";
            Field(x => x.Id, type:typeof(IdGraphType)).Description("Id Funcionário");
            Field(x => x.Nome).Description("Nome do funcionário");
            Field(x => x.CPF).Description("CPF do funcionario");
            Field(x => x.CargoId, type: typeof(IdGraphType)).Description("Id do cargo");
            FieldAsync<ListGraphType<CargoType>, List<Cargo>>("cargo",
                resolve: ctx =>
                {
                    return context.Cargos.Where(x => x.Id == ctx.Source.CargoId).ToListAsync();
                });
        }
    }
}
