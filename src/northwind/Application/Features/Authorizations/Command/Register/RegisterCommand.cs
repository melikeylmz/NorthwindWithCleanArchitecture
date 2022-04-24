using Application.Features.Authorizations.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
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

            public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public Task<RegistedDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
