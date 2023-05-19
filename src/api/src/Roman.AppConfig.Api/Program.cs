using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Roman.AppConfig.Api.Authentication;
using Roman.AppConfig.Api.Swagger;
using Roman.AppConfig.Infrastructure;
using Roman.CQRS.Abstraction.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Roman.AppConfig.Api
{
    /// <summary>
    /// Main program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Command line parameters</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services
                    .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>()
                    .AddSwaggerGen()
                    .AddFluentValidationRulesToSwagger();

            builder.Services.AddCompression();

            builder.Services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            builder.Services.AddFluentValidationAutoValidation(conf => { });
            builder.Services.AddFluentValidationClientsideAdapters(conf => { });

            builder.Services.AddMvc(options =>
            {
                options.Filters.Add(new ConsumesAttribute("application/json"));
                options.Filters.Add(new ProducesAttribute("application/json"));
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problems = new ApiErrorModel(context);
                    return new UnprocessableEntityObjectResult(problems);
                };
            });
            // .AddNewtonsoftJson(e => { })

            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            builder.Services.AddLocalization();

            builder.Services
                    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Authority = builder.Configuration["Authentication:Authority"];
                        options.RequireHttpsMetadata = false;
                        options.Audience = builder.Configuration["Authentication:Audience"];
                        options.TokenValidationParameters.ValidateIssuer = false;
                    })
                    .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationDefaults.AuthenticationScheme, options => { });

            builder.Services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            builder.Services.RegisterCommandsAndQueries();
            builder.Services.RegisterInfrastructureServices();

            var app = builder.Build();

            app.UseResponseCompression();

            // Configure the HTTP request pipeline.

            var supportedCultures = new[] { "en-US", "pl-PL", "pl", "en" };

            app.UseRequestLocalization(options => options
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures));

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "API");
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                var clientId = builder.Configuration["Authentication:ClientId"];
                c.OAuthClientId(clientId);
                var scopes = builder.Configuration["Authentication:Scope"]?.Split(" ");
                c.OAuthScopes(scopes);
                var audience = builder.Configuration["Authentication:Audience"] ?? throw new Exception("Authentication:Audience configuration key is absent");
                c.OAuthAdditionalQueryStringParams(new Dictionary<string, string> { { "audience", audience } });
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}