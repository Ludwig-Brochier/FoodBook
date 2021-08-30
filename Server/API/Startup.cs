using BLL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using API.GestionErreur;
using DocFx;

namespace API
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
            services.AddControllers().AddJsonOptions(options => 
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                // Ne pas serializer les valeurs nulles
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            });

            services.AddBLL();

            // Documentation utilisateur de l'API
            // Swagger
            services.AddOpenApiDocument(config =>
            {
                config.DocumentName = "API FoodBook V1.0";
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1.0";
                    document.Info.Title = "API FoodBook";
                    document.Info.Description = "Documentation à déstination de l'utilisateur de l'API FoodBook";
                    document.Info.TermsOfService = "Aucun";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Ludwig Brochier",
                        Email = "ludwig.brochier@gmail.com"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Utilisation à but pédagogique seulement"
                    };
                    config.ApiGroupNames = new[] { "1.0" };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();

            // Appel de la documentation utilisateur
            app.UseOpenApi(config =>
            {
                config.Path = "api/doc/{documentName}/api.json";
            });

            app.UseSwaggerUi3(config =>
            {
                config.DocumentPath = "api/doc/{documentName}/api.json";
                config.Path = "/api/doc";
            });
            // Fin appel de la documentation utilisateur

            ////Appel de la documentation technique
            //app.UseDocFx(config =>
            //{
            //    config.rootPath = "/doc";
            //});
            ////Fin appel de la documentation technique

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
