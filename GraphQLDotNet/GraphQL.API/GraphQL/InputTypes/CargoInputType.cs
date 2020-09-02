using Codeizi.DI.Helper.Anotations;
using GraphQL.Types;

namespace GraphQL.API.GraphQL.InputTypes
{
    [Injectable]
    public class CargoInputType : InputObjectGraphType
    {
        public CargoInputType()
        {
            Name = "CargoInput";
            Field<NonNullGraphType<StringGraphType>>("descricao");
        }
    }
}