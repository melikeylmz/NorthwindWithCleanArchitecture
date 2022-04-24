using Application.Features.Category.Rules;
using Application.Features.Products.Rules;
using Application.Services.AuthService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using Core.Mailing;
using Core.Mailing.MailkitImplementations;
using Core.Security.Jwt;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {


        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddSingleton<IMailService, MailkitMailService>();

            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<IAuthService,AuthManager>();
            services.AddTransient<ITokenHelper,JwtHelper>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}
