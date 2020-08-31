using GraphQL.API.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.GraphQL.Types
{
    public class CargoType : ObjectGraphType<Cargo>
    {
        public CargoType()
        {
            Name = "cargo";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id Cargo");
            Field(x => x.Descricao).Description("Nome do descrição");
        }
    }
}
