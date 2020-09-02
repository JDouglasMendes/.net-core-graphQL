using Codeizi.DI.Helper.Anotations;
using GraphQL.API.Models;
using GraphQL.Types;

namespace GraphQL.API.GraphQL.Types
{
    [Injectable]
    public class RoleType : ObjectGraphType<Role>
    {
        public RoleType()
        {
            Name = "cargo";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id Cargo");
            Field(x => x.Descricao).Description("Nome do descrição");
        }
    }
}