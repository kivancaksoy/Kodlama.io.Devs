using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimValidator : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimValidator()
        {
            RuleFor(o => o.Id).NotEmpty();
            RuleFor(o => o.Name).NotEmpty();
            RuleFor(o => o.Name).NotNull();
        }
    }
}
