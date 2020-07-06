using GraphQL.Types;
using PocGraphql.Infra.model;
using PocGraphql.Infra.repository;
using PocGraphql.Infra.types;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocGraphql.Infra.query
{
    public class BlogQuery : ObjectGraphType<object>
    {
        public BlogQuery(UsuarioRepository repositorio)
        {
            Field<ListGraphType<UsuarioType>>("usuario",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<IdGraphType>{Name="id"},
                    new QueryArgument<StringGraphType>{Name="nome"}
                }),
                resolve: contexto =>
                {
                    var filtro = new UsuarioFiltro()
                    {
                        Id = contexto.GetArgument<int>("id"),
                        Nome = contexto.GetArgument<string>("nome"),
                    };
                    return repositorio.ObterUsuarios(filtro);
                }

                );
        }
    }
}
