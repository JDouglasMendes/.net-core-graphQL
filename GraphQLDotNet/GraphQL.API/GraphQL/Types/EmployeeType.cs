using Codeizi.DI.Helper.Anotations;
using GraphQL.API.Context;
using GraphQL.API.Models;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.API.GraphQL.Types
{
    [Injectable]
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType(GraphQLContext context)
        {
            Name = "funcionario";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id Funcionário");
            Field(x => x.Name).Description("Nome do funcionário");
            Field(x => x.CPF).Description("CPF do funcionario");
            Field(x => x.RoleId, type: typeof(IdGraphType)).Description("Id do cargo");
            FieldAsync<ListGraphType<RoleType>, List<Role>>("cargo",
                resolve: ctx =>
                {
                    return context.Cargos.Where(x => x.Id == ctx.Source.RoleId).ToListAsync();
                });
        }
    }
}