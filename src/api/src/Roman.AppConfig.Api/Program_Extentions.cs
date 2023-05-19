using FluentValidation;
using Microsoft.AspNetCore.ResponseCompression;
using Roman.CQRS.Abstraction.Command;
using Roman.CQRS.Abstraction.CommandDecorators;
using Roman.CQRS.Abstraction.Query;
using Roman.CQRS.Abstraction.QueryDecorators;
using System.IO.Compression;

namespace Roman.AppConfig.Api
{
    /// <summary>
    /// Extentions used in Program.cs
    /// </summary>
    public static class ProgramExtensions
    {
        /// <summary>
        /// Add compression to response
        /// </summary>
        /// <param name="services"></param>
        public static void AddCompression(this IServiceCollection services)
        {
            services.AddResponseCompression(e => { e.EnableForHttps = true; });
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
        }

        /// <summary>
        /// Register commands and queries
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterCommandsAndQueries(this IServiceCollection services)
        {
            services.Scan(scan => scan
                            .FromAssemblies(typeof(Roman.AppConfig.Application.Registrations).Assembly)
                                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>))).AsImplementedInterfaces().WithScopedLifetime()
                                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>))).AsImplementedInterfaces().WithScopedLifetime()
                                .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>))).AsImplementedInterfaces().WithTransientLifetime()
                            );

            //services.Decorate(typeof(ICommandHandler<,>), typeof(OperationTypeCommandHandlerDecorator<,>));
            //services.Decorate(typeof(ICommandHandler<,>), typeof(ValidationCommandHandlerDecorator<,>));
            //services.Decorate(typeof(ICommandHandler<,>), typeof(CatchExceptionsCommandHandlerDecorator<,>));

            services.Decorate(typeof(IQueryHandler<,>), typeof(OperationTypeQueryHandlerDecorator<,>));
            services.Decorate(typeof(IQueryHandler<,>), typeof(CatchExceptionsQueryHandlerDecorator<,>));
        }
    }
}