using GraphQL.API.Context;
using GraphQL.API.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.Utils
{
    public static class InitDataBase
    {
        public static void InitData(this IServiceCollection serviceProvider)
        {
            var context = serviceProvider.BuildServiceProvider().GetService<GraphQLContext>();
            if (!context.Funcionario.Any())
            {
                var idCargo = Guid.NewGuid();

                context.Cargos.Add(new Cargo
                {
                    Id = idCargo,
                    Descricao = "Programador",
                });

                context.Funcionario.Add(new Funcionario
                {
                   Id = Guid.NewGuid(),
                   CargoId = idCargo,
                   Nome = "Funcionario 1",
                   CPF = "000.000.000-00",                   
                });

                context.SaveChanges();
            }
        }
    }
}
