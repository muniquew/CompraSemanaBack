using CompraSemana.Core.Data.Interfaces;
using CompraSemana.Core.Data.Repositories;
using CompraSemana.Core.Service;
using CompraSemana.Core.Service.DTO;
using CompraSemana.Core.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CompraSemana
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CompraSemana", Version = "v1" });
            });

            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<ICategoriaService, CategoriaService>();

            services.AddAutoMapper(typeof(MapperConfig));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompraSemana v1"));
            }

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
