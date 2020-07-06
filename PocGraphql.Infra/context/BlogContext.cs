using Microsoft.EntityFrameworkCore;
using PocGraphql.Infra.model;

namespace PocGraphql.Infra.context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> opcoes) : base(opcoes)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
