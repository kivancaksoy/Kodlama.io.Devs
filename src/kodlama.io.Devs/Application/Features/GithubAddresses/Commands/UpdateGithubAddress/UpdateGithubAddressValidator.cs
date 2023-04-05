using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Commands.UpdateGithubAddress
{
    public class UpdateGithubAddressValidator : AbstractValidator<GithubAddress>
    {
        public UpdateGithubAddressValidator()
        {
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.Address).NotNull();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.UserId).NotNull();
        }
    }
}
