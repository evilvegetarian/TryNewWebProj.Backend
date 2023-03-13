using FluentValidation;

namespace TryNewWebProj.Application.Languages.Commands.CreateCommand
{
    public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageCommandValidator()
        {
            RuleFor(lang =>
                lang.Title).NotEmpty().MaximumLength(30);
            RuleFor(lang =>
                lang.UserId).NotEqual(Guid.Empty);
        }
    }
}
