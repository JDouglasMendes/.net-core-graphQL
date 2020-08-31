using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.GraphQL.InputTypes
{
    public class FuncionarioInputType : InputObjectGraphType
    {
        public FuncionarioInputType()
        {
            Name = "FuncionarioInput";
            Field<NonNullGraphType<StringGraphType>>("nome");
            Field<NonNullGraphType<StringGraphType>>("cpf");
            Field<NonNullGraphType<StringGraphType>>("cargoid");
        }
    }
}
