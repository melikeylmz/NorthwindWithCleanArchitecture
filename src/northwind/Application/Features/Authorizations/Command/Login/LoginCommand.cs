using Application.Features.Authorizations.Dtos;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConserns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Core.Security.Jwt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authorizations.Command.Login
{
    public  class LoginCommand : IRequest<LogedInDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LogedInDto>
        {
            IUserRepository _userRepository;
            IAuthService _authService;

            public LoginCommandHandler(IUserRepository userRepository, IAuthService authService)
            {
                _userRepository = userRepository;
                _authService = authService;
            }

         

            public async Task<LogedInDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var userToCheck =  await _userRepository.GetAsync(w=>w.Email==request.UserForLoginDto.Email);
                if (userToCheck == null)
                { throw new BusinessException("Kullanıcı bulunamadı"); }


                if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                {
                    throw new BusinessException("Paralo hatası");
                }

                AccessToken createdAccessToken = await _authService.CreateAccessToken(userToCheck);


                LogedInDto logedInDto = new LogedInDto { AccessToken = createdAccessToken };

                return logedInDto;

            }

        }
    }

    }

