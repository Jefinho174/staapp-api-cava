using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using StaminaApp.Domain.Repositorios;
using StaminaApp.Infra.EntidadeMap;
using StaminaApp.Infra.Repositorios;
using Swashbuckle.AspNetCore.Swagger;

namespace StaminaApp.WebApi
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
            MapeamentoEntidades.LoadEntidadesMap();
            services.AddScoped<IEmpresaRepositorio>(factory =>
            {
                return new EmpresaRepositorio(Configuration.GetConnectionString("MySqlDbConnection"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "StaminaApp - Cava - WebApi",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Jeferson Luiz",
                        Url = "https://github.com/Jefinho174"
                    }
                });
            });
            var assembly = AppDomain.CurrentDomain.Load("StaminaApp.Domain");
            services.AddMediatR(assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StaminaApp - Controle Patrimonial");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
