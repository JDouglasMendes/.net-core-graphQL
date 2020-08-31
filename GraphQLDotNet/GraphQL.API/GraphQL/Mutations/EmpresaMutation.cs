using GraphQL.API.Context;
using GraphQL.API.GraphQL.InputTypes;
using GraphQL.API.GraphQL.Types;
using GraphQL.API.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.GraphQL.Mutations
{
    public class EmpresaMutation : ObjectGraphType
    {
        public EmpresaMutation(GraphQLContext db)
        {
            FieldAsync<CargoType>(
                                 "createCargo",
                                 arguments: new QueryArguments(
                                     new QueryArgument<NonNullGraphType<CargoInputType>> { Name = "cargo" }
                                 ),
                                 resolve: async context =>
                                 {
                                     var cargo = context.GetArgument<Cargo>("cargo");
                                     await db.Cargos.AddAsync(cargo);
                                     await db.SaveChangesAsync();
                                     return cargo;
                                 });


            FieldAsync<FuncionarioType>("createFuncionario",
                     arguments: new QueryArguments(
                                     new QueryArgument<NonNullGraphType<FuncionarioInputType>> { Name = "funcionario" }
                                 ),
                      resolve: async context =>
                      {
                          var funcionario = context.GetArgument<Funcionario>("funcionario");
                          await db.Funcionario.AddAsync(funcionario);
                          await db.SaveChangesAsync();
                          return funcionario;
                      });


        }


    }
}
