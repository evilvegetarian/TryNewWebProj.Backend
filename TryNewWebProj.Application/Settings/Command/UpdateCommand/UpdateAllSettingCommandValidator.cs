using FluentValidation;

namespace TryNewWebProj.Application.Settings.Command.UpdateCommand
{
    public class UpdateAllSettingCommandValidator : AbstractValidator<UpdateAllSettingCommand>
    {
        public UpdateAllSettingCommandValidator()
        {
            RuleFor(sett => sett.UserId).NotEqual(Guid.Empty);
        }
    }
}
