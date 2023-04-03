using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.Id).NotNull();
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Name).NotNull();
            RuleFor(t => t.ProgrammingLanguageId).NotEmpty();
            RuleFor(t => t.ProgrammingLanguageId).NotNull();
        }
    }
}
