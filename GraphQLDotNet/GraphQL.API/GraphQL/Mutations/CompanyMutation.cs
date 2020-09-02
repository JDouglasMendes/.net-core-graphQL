using Codeizi.DI.Helper.Anotations;
using GraphQL.API.Context;
using GraphQL.API.GraphQL.InputTypes;
using GraphQL.API.GraphQL.Types;
using GraphQL.API.Models;
using GraphQL.Types;

namespace GraphQL.API.GraphQL.Mutations
{
    [Injectable]
    public class CompanyMutation : ObjectGraphType
    {
        public CompanyMutation(GraphQLContext db)
        {
            FieldAsync<RoleType>(
                                 "createCargo",
                                 arguments: new QueryArguments(
                                     new QueryArgument<NonNullGraphType<CargoInputType>> { Name = "cargo" }
                                 ),
                                 resolve: async context =>
                                 {
                                     var cargo = context.GetArgument<Role>("cargo");
                                     await db.Cargos.AddAsync(cargo);
                                     await db.SaveChangesAsync();
                                     return cargo;
                                 });

            FieldAsync<EmployeeType>("createFuncionario",
                     arguments: new QueryArguments(
                                     new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "funcionario" }
                                 ),
                      resolve: async context =>
                      {
                          var funcionario = context.GetArgument<Employee>("funcionario");
                          await db.Funcionario.AddAsync(funcionario);
                          await db.SaveChangesAsync();
                          return funcionario;
                      });
        }
    }
}