using GraphQL.Types;
using PocGraphql.Infra.model;

namespace PocGraphql.Infra.types
{
    public class UsuarioInputType : InputObjectGraphType<Usuario>
    {
        public UsuarioInputType()
        {
            Name = "UsuarioInput";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id usuário");
            Field(x => x.Idade).Description("Idade do usuário");
            Field(x => x.Nome).Description("Nome do usuário");
            Field(x => x.DataCriacao, type: typeof(DateTimeGraphType)).Description("Data criação usuário");
            Field(x => x.DataAlteracao, type: typeof(DateTimeGraphType)).Description("Data alteração usuário");
        }
    }
}
