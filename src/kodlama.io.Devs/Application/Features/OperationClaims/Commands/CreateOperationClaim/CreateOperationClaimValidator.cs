using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimValidator : AbstractValidator<CreateOperationClaimCommand>
    {
        public CreateOperationClaimValidator()
        {
            RuleFor(o => o.Name).NotEmpty();
            RuleFor(o => o.Name).NotNull();
        }
    }
}
