using FluentValidation;

namespace TryNewWebProj.Application.Languages.Commands.DeleteCommand
{
    public class DeleteLanguageCommandValidator : AbstractValidator<DeleteLanguageCommand>
    {
        public DeleteLanguageCommandValidator()
        {
            RuleFor(lang => lang.Id).NotEqual(Guid.Empty);
            RuleFor(lang => lang.UserId).NotEqual(Guid.Empty);
        }
    }
}
