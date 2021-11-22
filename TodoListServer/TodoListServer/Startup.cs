using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListServer.Data;
using TodoListServer.GraphQL.Mutation;
using TodoListServer.GraphQL.Query;

namespace TodoListServer
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
            services.AddRazorPages();

            services.AddDbContextFactory<GraphQLDbContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("Default")));

            services.AddCors(option => option.AddPolicy("AllowAllOrigin", 
                builder => builder.WithOrigins("https://localhost:44309").AllowAnyHeader().AllowAnyMethod()));

            services
                .AddGraphQLServer()
                .AddMutationType<GraphQLMutation>()
                .AddQueryType<GraphQLQuery>();

            services.AddScoped<GraphQLQuery>();
            services.AddScoped<GraphQLMutation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("AllowAllOrigin");

            app.UseAuthorization();

            app.UseEndpoints(x => x.MapGraphQL());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => 
                {
                    await context.Response.WriteAsync("Hello World!");


                });
            });
        }
    }
}
