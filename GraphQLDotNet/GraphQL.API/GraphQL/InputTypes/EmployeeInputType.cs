using Codeizi.DI.Helper.Anotations;
using GraphQL.Types;

namespace GraphQL.API.GraphQL.InputTypes
{
    [Injectable]
    public class EmployeeInputType : InputObjectGraphType
    {
        public EmployeeInputType()
        {
            Name = "FuncionarioInput";
            Field<NonNullGraphType<StringGraphType>>("nome");
            Field<NonNullGraphType<StringGraphType>>("cpf");
            Field<NonNullGraphType<StringGraphType>>("cargoid");
        }
    }
}