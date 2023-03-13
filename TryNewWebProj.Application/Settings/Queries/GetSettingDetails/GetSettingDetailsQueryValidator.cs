using FluentValidation;

namespace TryNewWebProj.Application.Settings.Queries.GetSettingDetails
{
    public class GetSettingDetailsQueryValidator : AbstractValidator<GetSettingDetailsQuery>
    {
        public GetSettingDetailsQueryValidator()
        {
            RuleFor(sett => sett.Id).NotEqual(Guid.Empty);
        }
    }
}
