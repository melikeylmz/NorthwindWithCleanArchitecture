using Application.Features.UserOperationClaims.Commands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.Create
{
    public  class CreatedUserOperationClaimCommand:IRequest<CreatedUserOperationClaimDto>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }


        public class CreatedUserOperationClaimHandle : IRequestHandler<CreatedUserOperationClaimCommand, CreatedUserOperationClaimDto>
        {

            public IUserOperationClaimRepository _operationClaimRepository;
            public   IMapper _mapper;

            public CreatedUserOperationClaimHandle(IUserOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<CreatedUserOperationClaimDto> Handle(CreatedUserOperationClaimCommand request, CancellationToken cancellationToken)
            {

                var userOperationClaim = _mapper.Map<UserOperationClaim>(request);
                var addUserClaim=await  _operationClaimRepository.AddAsync(userOperationClaim);
              
              return _mapper.Map<CreatedUserOperationClaimDto>(addUserClaim);


            }
        }

    }
}
