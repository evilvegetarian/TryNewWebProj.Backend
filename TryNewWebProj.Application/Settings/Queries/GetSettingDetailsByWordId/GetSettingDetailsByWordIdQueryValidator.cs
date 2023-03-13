using FluentValidation;

namespace TryNewWebProj.Application.Settings.Queries.GetSettingDetailsByWordId
{
    public class GetSettingDetailsByWordIdQueryValidator : AbstractValidator<GetSettingDetailsByWordIdQuery>
    {
        public GetSettingDetailsByWordIdQueryValidator()
        {
            RuleFor(sett => sett.WordId).NotEqual(Guid.Empty);
        }
    }
}
