using System;
using System.IO;
using System.Reflection;
using CopaFilmes.Api.Filters;
using CopaFilmes.Domain.Interfaces.ApiServices;
using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Domain.Services;
using CopaFilmes.Infra.ApiServices;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CopaFilmes.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private static Assembly DomainAssembly => AppDomain.CurrentDomain.Load("CopaFilmes.Domain");

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(config =>
                {
                    config.Filters.Add<FluentValidationFilter>();
                })
                .AddFluentValidation(config =>
                {
                    config.RegisterValidatorsFromAssembly(DomainAssembly);
                    config.DisableDataAnnotationsValidation = true;
                });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CopaFilmes.Api",
                    Version = "v1"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });

            services.AddHttpClient<IFilmeApiService, FilmeApiService>(
                config =>
                {
                    config.BaseAddress = new Uri(Configuration.GetValue<string>("FilmeApi:Endpoint"));
                    config.Timeout = TimeSpan.FromSeconds(30);
                });

            services.AddScoped<ICopaService, CopaService>();

            services.AddMediatR(DomainAssembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CopaFilmes.Api v1"));
            }

            app.UseCors(config =>
                config.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
