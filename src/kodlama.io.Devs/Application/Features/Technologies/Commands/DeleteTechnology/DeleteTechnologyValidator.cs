using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyValidator : AbstractValidator<DeleteTechnologyCommand>
    {
        public DeleteTechnologyValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.Id).NotNull();
        }
    }
}
