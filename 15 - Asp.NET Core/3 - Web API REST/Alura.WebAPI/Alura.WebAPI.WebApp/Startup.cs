﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Alura.ListaLeitura.HttpClients;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Alura.ListaLeitura.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            // Utilizando Autenticação via Cookies
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Usuario/Login";
                });

            // Utilizando o IHttpContextAccessor
            services.AddHttpContextAccessor();

            // Definindo BaseAddress para classe LivroApiClient
            services.AddHttpClient<LivroApiClient>(client => {
                client.BaseAddress = new System.Uri("http://localhost:6000/api/");
            });

            // Definindo BaseAddress para classe AuthApiClient
            services.AddHttpClient<AuthApiClient>(client => {
                client.BaseAddress = new System.Uri("http://localhost:5000/api/");
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}