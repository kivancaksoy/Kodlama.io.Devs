using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGithubAddressValidator : AbstractValidator<CreateGithubAddressCommand>
    {
        public CreateGithubAddressValidator()
        {
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.Address).NotNull();
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
}
