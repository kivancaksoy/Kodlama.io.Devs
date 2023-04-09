using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimValidator : AbstractValidator<DeleteUserOperationClaimCommand>
    {
        public DeleteUserOperationClaimValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
        }
    }
}
