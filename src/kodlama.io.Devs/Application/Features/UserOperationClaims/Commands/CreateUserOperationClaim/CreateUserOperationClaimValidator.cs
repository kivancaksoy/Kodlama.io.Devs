using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimValidator : AbstractValidator<CreateUserOperationClaimCommand>
    {
        public CreateUserOperationClaimValidator() 
        {
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.OperationClaimId).NotEmpty();
        }
    }
}
