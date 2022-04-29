using Application.Features.Payments.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Validations
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {

        public CreatePaymentCommandValidator()
        {
            RuleFor(p => p.CreditCartNo).NotEmpty().Length(16).Matches("[0-9]");
            RuleFor(p => p.ExpirationDate).NotEmpty().Matches("(0[1-9]|1[0-2])([012][0-9]|19[0-9][0-9])|([0-9]|2[0153])");
         
        }

       
    }
}
