using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.ListaLeitura.Api.Formatters;
using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Alura.WebAPI.Api.Filtros;
using Alura.WebAPI.Api.Filtros.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Alura.WebAPI.Api
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
            #region Conexão com Banco

            services.AddDbContext<LeituraContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("ListaLeitura"));
            });

            #endregion

            #region Injeção de dependencias

            services.AddTransient<IRepository<Livro>, RepositorioBaseEF<Livro>>();

            #endregion

            #region Formatador Resposta API (Json, Xml, etc...) E Tratamento de Excetpion
            
            services.AddMvc(options => {

                // Classe de tratamento de erros API
                options.Filters.Add(typeof(ErrorResponseFilter));

                //Formatadores Resposta
                options.OutputFormatters.Add(new LivroCsvFormatter()); // Formatador para CSV
            }).AddXmlSerializerFormatters(); // Adicionando configuração para serializar para xml (Api retornar resposta tanto em json quanto em xml) // Microsoft.AspNetCore.Mvc.Formatters.Xml (Pacote para utilizar serialização para xml)

            // Desativando o tratamento padrão de erros do .net core para ModelState
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            #endregion

            #region Autenticação (Token JWT)

            // Configuração de validação Token JWT

            //Pacotes para utilizar authenticação via JWT
            //Microsoft.AspNetCore.Authentication.JwtBearer
            //System.IdentityModel.Tokens.Jwt

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                // Parametros que seram validados no token JWT
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("alura-webapi-authentication-valid")), // Chave de validação
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidIssuer = "Alura.WebApp",
                    ValidAudience = "Postman"
                };
            });

            #endregion

            #region Versionamento API

            // Utilizando Versionamento (Biblioteca : Microsoft.AspNetCore.Mvc.Versioning)
            services.AddApiVersioning( options => 
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                // Definindo por onde sera recebido o parametro de versão
                //options.ApiVersionReader = ApiVersionReader.Combine(
                //        new QueryStringApiVersionReader("api-version"), // Receber o parametro de versão pela QueryString, com a chave expecificada
                //        new HeaderApiVersionReader("api-version") // Receber o parametro de versão pelo header, com a chave expecificada
                //    );
            });

            #endregion

            #region Configurando Swagger

            // Biblioteca (Swashbuckle.AspNetCore)
            // Biblioteca (Swashbuckle.AspNetCore.Annotations) (Anotações custumizadas)
            services.AddSwaggerGen(c =>
            {
                // Versões Documentação
                c.SwaggerDoc("v1", new Info { Title = "Livros API", Description = "Documentação da API", Version = "1.0" });
                c.SwaggerDoc("v2", new Info { Title = "Livros API", Description = "Documentação da API", Version = "2.0" });

                // Anotações personalizadas
                c.EnableAnnotations();
                //definição do esquema de segurança utilizado
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey",
                    Description = "Autenticação Bearer via JWT"
                });
                //que operações usam o esquema acima - todas
                c.AddSecurityRequirement(
                    new Dictionary<string, IEnumerable<string>> {
                        { "Bearer", new string[] { } }
                });
                //descrevendo enumerados como strings
                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();
                //adicionando o filtro para incluir respostas 401 nas operações
                c.OperationFilter<AuthResponsesOperationFilter>();
                //adicionando o filtro para incluir descrições nas tags
                c.DocumentFilter<TagDescriptionsDocumentFilter>();
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc();

            // Para usar o Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
            });
        }
    }
}
