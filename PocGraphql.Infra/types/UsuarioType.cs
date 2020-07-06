using GraphQL.Types;
using PocGraphql.Infra.model;

namespace PocGraphql.Infra.types
{
    public class UsuarioType : ObjectGraphType<Usuario>
    {
        public UsuarioType()
        {
            Name = "Usuario";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id usuário");
            Field(x => x.Idade).Description("Idade do usuário");
            Field(x => x.Nome).Description("Nome do usuário");
            Field(x => x.DataCriacao).Description("Data criação usuário");
            Field(x => x.DataAlteracao).Description("Data alteração usuário");
        }
    }
}
