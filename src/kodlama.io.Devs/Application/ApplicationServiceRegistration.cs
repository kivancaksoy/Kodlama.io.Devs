using Application.Features.ProgrammingLanguages.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Core.Application.Pipelines.Validation;
using Application.Features.Technologies.Rules;
using Application.Services.AuthService;
using Application.Features.Auths.Rules;
using Application.Features.GithubAddresses.Rules;
using Application.Features.OperationClaims.Rules;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<TechnologyBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<AuthBusinessRules>();

            services.AddScoped<GithubAddressBusinessRules>();

            services.AddScoped<OperationClaimBusinessRules>();

            return services;
        }
    }
}
