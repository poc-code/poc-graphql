using GraphQL;
using GraphQL.Types;
using PocGraphql.Infra.model;
using PocGraphql.Infra.repository;
using PocGraphql.Infra.types;

namespace PocGraphql.Infra.mutation
{
    public class BlogMutation : ObjectGraphType<object>
    {
        public BlogMutation(UsuarioRepository repositorio)
        {
            Name = "Mutation";
            Field<UsuarioType>("criarUsuario",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UsuarioInputType>> { Name = "usuario" }
                ),
                resolve: context =>
                {
                    var usuario = context.GetArgument<Usuario>("usuario");
                    return repositorio.Adicionar(usuario);
                });

            Field<UsuarioType>("alterarUsuario",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UsuarioInputType>> { Name = "usuario" },
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "usuarioId" }
                ),
                resolve: context =>
                {
                    var usuario = context.GetArgument<Usuario>("usuario");
                    var id = context.GetArgument<int>("usuarioId");

                    var dbUsuario = repositorio.ObterUsuarioPorId(id);
                    if (dbUsuario == null)
                    {
                        context.Errors.Add(new ExecutionError("Não foi possivel encontrar usuário na base de dados."));
                        return null;
                    }
                    return repositorio.Alterar(dbUsuario, usuario);
                });

            Field<StringGraphType>("removerUsuario",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "usuarioId" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("usuarioId");
                    var dbUsuario = repositorio.ObterUsuarioPorId(id);
                    if (dbUsuario == null)
                    {
                        context.Errors.Add(new ExecutionError("Não foi possivel encontrar usuário na base de dados."));
                        return null;
                    }
                    repositorio.Remover(dbUsuario);
                    return $"O usuario com id {id} foi removido";
                });
        }
    }
}
