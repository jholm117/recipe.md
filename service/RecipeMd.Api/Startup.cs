using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecipeMd.Backend;
using RecipeMd.Domain.Interfaces;
using RecipeMd.Domain.Services;
using Serilog;

namespace RecipeMd.Api
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

            services.AddControllersWithViews(options =>
            {
                options.OutputFormatters.Insert(0, new MarkdownOutputFormatter());
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/build");

            services.AddHealthChecks();

            services.AddTransient<IRecipeDocumentTranslator, RecipeDocumentTranslator>();
            services.AddTransient<IParser, Parser>();
            services.AddTransient<IMarkdownGenerator, MarkdownGenerator>(services => new MarkdownGenerator(System.IO.File.ReadAllText(Configuration["handlebarsTemplatePath"])));

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
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseSpaStaticFiles(new StaticFileOptions
            {
                // OnPrepareResponse = context =>
                // {
                //     context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                //     context.Context.Response.Headers.Add("Expires", "0");
                // }
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "recipe",
                    pattern: "recipe/{*uri}",
                    defaults: new { controller = "Recipe", action = "Get" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");


                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
                {
                    Predicate = (_) => false
                });

                endpoints.MapHealthChecks("/health/live", new HealthCheckOptions()
                {
                    Predicate = (_) => false
                });
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseReactDevelopmentServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");

                }
            });
        }
    }
}
