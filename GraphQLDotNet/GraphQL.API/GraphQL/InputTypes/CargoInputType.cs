using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.GraphQL.InputTypes
{
    public class CargoInputType : InputObjectGraphType
    {
        public CargoInputType()
        {
            Name = "CargoInput";
            Field<NonNullGraphType<StringGraphType>>("descricao");            
        }
    }
}
