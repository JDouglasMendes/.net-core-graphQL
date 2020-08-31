using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL.API.Context;
using GraphQL.API.GraphQL.InputTypes;
using GraphQL.API.GraphQL.Mutations;
using GraphQL.API.GraphQL.Queries;
using GraphQL.API.GraphQL.Schemas;
using GraphQL.API.GraphQL.Types;
using GraphQL.API.Utils;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphQL.API
{
    public class Startup
    {
        public static readonly ILoggerFactory MyLoggerFactory
= LoggerFactory.Create(builder => { builder.AddConsole(); });

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
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

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));      
            services.AddScoped<EmpresaSchema>();
            services.AddScoped<EmpresaQuery>();
            services.AddScoped<FuncionarioType>();
            services.AddScoped<CargoType>();
            services.AddScoped<CargoInputType>();
            services.AddScoped<FuncionarioInputType>();
            services.AddScoped<EmpresaMutation>();

            services.InitData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
