using Application.Features.Authorizations.Dtos;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.Jwt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authorizations.Command.Register
{
    public class RegisterCommand:IRequest<RegistedDto>
    {
        public UserForRegisterDto userForRegisterDto { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegistedDto>
        {

            IUserRepository _userRepository;
            IMapper _mapper;
            IAuthService _authService;

            public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthService authService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authService = authService;
            }

            public async Task<RegistedDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
               

                byte[] passWordHash, passWordSalt;
                HashingHelper.CreatePasswordHash(request.userForRegisterDto.Password, out passWordHash, out passWordSalt);


               User user = new User {
                   Email = request.userForRegisterDto.Email,
                   FirstName = request.userForRegisterDto.FirstName,
                   LastName = request.userForRegisterDto.LastName,
                   PasswordHash = passWordHash,
                   PasswordSalt = passWordSalt

               };

                User createdUser = await _userRepository.AddAsync(user);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                

                RegistedDto registedDto = new RegistedDto { AccessToken = createdAccessToken };

                return registedDto;
            }
        }
    }
}
