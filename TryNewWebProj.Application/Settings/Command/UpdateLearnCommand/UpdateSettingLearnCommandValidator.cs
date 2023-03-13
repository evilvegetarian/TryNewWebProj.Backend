using FluentValidation;

namespace TryNewWebProj.Application.Settings.Command.UpdateCommand
{
    public class UpdateSettingLearnCommandValidator : AbstractValidator<UpdateSettingLearnCommand>
    {
        public UpdateSettingLearnCommandValidator()
        {
            RuleFor(sett => sett.WordId).NotEqual(Guid.Empty);
        }
    }
}
