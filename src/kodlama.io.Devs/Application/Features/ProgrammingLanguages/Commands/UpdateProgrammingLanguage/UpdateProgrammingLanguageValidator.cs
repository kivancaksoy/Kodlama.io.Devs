using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).NotNull();
        }
    }
}
