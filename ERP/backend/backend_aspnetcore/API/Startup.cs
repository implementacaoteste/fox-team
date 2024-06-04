using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
                        // Adiciona suporte ao controlador
            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        // Define o manipulador de referência para ignorar ciclos
                        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                    });
            // Adiciona suporte ao controlador
            services.AddControllers();

            // Adiciona o gerador Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // Este método é usado para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Verifica se o ambiente é de desenvolvimento
            if (env.IsDevelopment())
            {
                // Exibe página de erro detalhada apenas em ambiente de desenvolvimento
                app.UseDeveloperExceptionPage();

                // Habilita o middleware do Swagger
                app.UseSwagger();

                // Especifica o endpoint Swagger JSON
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                    //c.RoutePrefix = string.Empty; // Define a raiz do Swagger UI para a raiz da aplicação
                });
            }
            else
            {
                // Redireciona para HTTPS em ambientes de produção
                app.UseHttpsRedirection();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Habilita roteamento
            app.UseRouting();

            // Habilita autorização (se necessário)
            // app.UseAuthorization();

            // Configura os endpoints
            app.UseEndpoints(endpoints =>
            {
                // Mapeia os endpoints dos controladores
                endpoints.MapControllers();
                // Configura o endpoint padrão para servir o arquivo index.html
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
