using GraphiQl;
using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PocGraphql.Infra.context;
using PocGraphql.Infra.mutation;
using PocGraphql.Infra.query;
using PocGraphql.Infra.repository;
using PocGraphql.Infra.schema;
using PocGraphql.Infra.types;

namespace PocGraphql
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));//para poder injetar repositório na classe BlogQuery
            services.AddTransient<UsuarioRepository, UsuarioRepository>();
            services.AddScoped<BlogSchema>();
            services.AddScoped<BlogQuery>();
            services.AddScoped<BlogMutation>();
            services.AddScoped<UsuarioType>();
            services.AddDbContext<BlogContext>(opcoes => opcoes.UseInMemoryDatabase(databaseName: "Blog"));

            #region Configuração do Cors CrossOrigins
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphiQl();//adicione interface do grapiql antes do UseMvc
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
