using FluentValidation;

namespace TryNewWebProj.Application.Words.Command.CreateCommand
{
    public class CreateWordCommandValidator : AbstractValidator<CreateWordCommand>
    {
        public CreateWordCommandValidator()
        {
            RuleFor(dict => dict.LanguageId).NotEqual(Guid.Empty);
            RuleFor(dict => dict.WordValue).NotEmpty().MaximumLength(250);
            RuleFor(dict => dict.Translate).NotEmpty().MaximumLength(250);

        }
    }
}
