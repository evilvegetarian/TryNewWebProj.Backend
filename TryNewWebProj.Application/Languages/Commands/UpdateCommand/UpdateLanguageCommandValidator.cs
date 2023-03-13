using FluentValidation;

namespace TryNewWebProj.Application.Languages.Commands.UpdateCommand
{
    public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
    {
        public UpdateLanguageCommandValidator()
        {
            RuleFor(lang => lang.UserId).NotEqual(Guid.Empty);
            RuleFor(lang => lang.Id).NotEqual(Guid.Empty);
            RuleFor(lang => lang.Title).NotEmpty().MaximumLength(250);
        }
    }
}
