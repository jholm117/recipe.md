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
using Serilog.Events;

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

            services.AddTransient<IRecipePresenter, RecipePresenter>();
            services.AddTransient<IMetadataPresenter, MetadataPresenter>();
            services.AddTransient<IParser, Parser>();
            services.AddTransient<IDomainSelectorProvider, DomainSelectorProvider>();
            var markdownGenerator = new MarkdownGenerator(new TemplateProvider("handlebars-templates/recipe-template.handlebars"));
            var markdownProcessor = new MarkdownProcessor();
            services.AddControllers((options) =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;

                options.OutputFormatters.Insert(0, new MarkdownOutputFormatter(markdownGenerator, markdownProcessor));
            });

            services.AddOpenApiDocument();

            services.AddHealthChecks();
            // In production, the React files will be served from this directory
            // services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/build");


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSerilogRequestLogging(options => options.GetLevel = (context, NumberFormatInfo, exception) =>
            {
                return context.Request.Path.ToString() switch
                {
                    "/health/live" => LogEventLevel.Debug,
                    "/health/ready" => LogEventLevel.Debug,
                    _ => LogEventLevel.Information
                };
            });

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
                {
                    Predicate = (_) => false
                });

                endpoints.MapHealthChecks("/health/live", new HealthCheckOptions()
                {
                    Predicate = (_) => false
                });
            });

            // app.UseSpa(spa =>
            // {
            //     spa.Options.SourcePath = "ClientApp";

            //     if (env.IsDevelopment())
            //     {
            //         spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");

            //     }
            // });
        }
    }
}
