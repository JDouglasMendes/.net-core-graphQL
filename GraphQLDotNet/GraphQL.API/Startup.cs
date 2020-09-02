using Codeizi.DI.AspNetCore;
using GraphiQl;
using GraphQL.API.Context;
using GraphQL.API.GraphQL.InputTypes;
using GraphQL.API.GraphQL.Mutations;
using GraphQL.API.GraphQL.Queries;
using GraphQL.API.GraphQL.Schemas;
using GraphQL.API.GraphQL.Types;
using GraphQL.API.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphQL.API
{
    public sealed class Startup
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddMvc(x => x.EnableEndpointRouting = false);

            services.AddDbContext<GraphQLContext>(
                options =>
                options.UseLoggerFactory(MyLoggerFactory).
                UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                        x => x.MigrationsAssembly("GraphQL.API")));

            services.AddScoped<IDependencyResolver>(s =>
                               new FuncDependencyResolver(
                                   s.GetRequiredService));
  

            services.AddInjectables(this.GetType().Assembly);

            services.InitData();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}