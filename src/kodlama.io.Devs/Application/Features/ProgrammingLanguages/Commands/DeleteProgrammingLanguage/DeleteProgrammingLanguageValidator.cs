using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).NotNull();
        }
    }
}
