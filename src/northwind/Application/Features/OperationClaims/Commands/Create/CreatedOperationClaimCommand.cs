using Application.Features.OperationClaims.Commands.Dtos;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.Create
{
    public  class CreatedOperationClaimCommand:IRequest<CreatedOperationClaimDto>
    {
        public string Name { get; set; }

        public class CreatedOperationClaimHandler : IRequestHandler<CreatedOperationClaimCommand, CreatedOperationClaimDto>
        {
            IOperationClaimRepository _operationClaimRepository;

            public CreatedOperationClaimHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreatedOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = new OperationClaim
                { Name = request.Name };

                OperationClaim addedClaim = await _operationClaimRepository.AddAsync(operationClaim);
                CreatedOperationClaimDto createdOperationClaimDto = new CreatedOperationClaimDto { Name = addedClaim.Name,Id=addedClaim.Id };
                return createdOperationClaimDto;

            }

        }
        }
    }

