using GraphQL_API.Database;
using GraphQL_API.GraphQL;
using GraphQL_API.Models;
using GraphQL_API.Services;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }
        private readonly string _policyName = "CorsPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddScoped<IUser, UserService>();
            services.AddScoped<IPost, PostService>();
            services.AddScoped<IComment, CommentService>();
            services.AddDbContext<GraphQLDbContext>(context =>
            {
                context.UseNpgsql(Configuration.GetConnectionString("ConnectionString"));
            });

            services.AddGraphQLServer()
                .AddType<UserType>()
                .AddType<PostType>()
                .AddType<CommentType>()
                .AddQueryType<Query>()
                .AddFiltering()
                .AddSorting()
                .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
                .AddMutationType<Mutation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GraphQLDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions {QueryPath = "/api", Path = "/playground"});
            }

            dbContext.Database.EnsureCreated();

            app.UseRouting();
            
            app.UseCors(_policyName);
            
            app.UseEndpoints(endpoints => { endpoints.MapGraphQL("/api"); });
        }
    }
}