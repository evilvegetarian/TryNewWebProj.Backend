using FluentValidation;

namespace TryNewWebProj.Application.Words.Command.UpdateCommand
{
    public class UpdateWordValidator : AbstractValidator<UpdateWordCommand>
    {
        public UpdateWordValidator()
        {
            RuleFor(dict => dict.LanguageId).NotEqual(Guid.Empty);
            RuleFor(dict => dict.Id).NotEqual(Guid.Empty);
            RuleFor(dict => dict.WordValue).NotEmpty().MaximumLength(250);
            RuleFor(dict => dict.Translate).NotEmpty().MaximumLength(250);
        }
    }
}
