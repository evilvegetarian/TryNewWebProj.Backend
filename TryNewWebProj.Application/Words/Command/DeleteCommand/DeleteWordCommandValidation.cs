using FluentValidation;

namespace TryNewWebProj.Application.Words.Command.DeleteCommand
{
    public class DeleteWordCommandValidation : AbstractValidator<DeleteWordCommand>
    {
        public DeleteWordCommandValidation()
        {
            RuleFor(dict => dict.Id).NotEqual(Guid.Empty);
        }
    }
}
