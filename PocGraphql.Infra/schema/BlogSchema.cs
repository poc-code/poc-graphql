using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using PocGraphql.Infra.mutation;
using PocGraphql.Infra.query;
using System;

namespace PocGraphql.Infra.schema
{
    public class BlogSchema : Schema
    {

        public BlogSchema(IServiceProvider serviceProvider)
        : base()
        {
            Query = serviceProvider.GetRequiredService<BlogQuery>();
            Mutation = serviceProvider.GetRequiredService<BlogMutation>();

        }
    }
}
