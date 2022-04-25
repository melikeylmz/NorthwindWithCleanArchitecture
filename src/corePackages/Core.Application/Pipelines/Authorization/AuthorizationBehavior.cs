using Core.CrossCuttingConserns.Exceptions;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            List<string> roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            bool isClaimRolesMatchedWithRequestRoles = roleClaims.FirstOrDefault(roleclaim => request.Roles.Any(role => role == roleclaim)).IsNullOrEmpty();

            if (isClaimRolesMatchedWithRequestRoles)
            {
                throw new BusinessException("You are not authorized");
            }

            TResponse response = await next();
            return response;

        }
    }
}