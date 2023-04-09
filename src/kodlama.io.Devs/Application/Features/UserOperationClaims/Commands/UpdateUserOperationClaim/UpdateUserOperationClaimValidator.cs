using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimValidator : AbstractValidator<UpdateUserOperationClaimCommand>
    {
        public UpdateUserOperationClaimValidator() 
        {
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.OperationClaimId).NotEmpty();
        }
    }
}
