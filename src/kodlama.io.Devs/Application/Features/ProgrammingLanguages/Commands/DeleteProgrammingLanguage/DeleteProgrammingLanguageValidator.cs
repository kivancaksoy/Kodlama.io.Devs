using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Id).NotNull();
        }
    }
}
