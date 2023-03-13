using FluentValidation;

namespace TryNewWebProj.Application.Languages.Queries.GetlanguageDetails
{
    public class GetLanguageDetailsQueryValidator : AbstractValidator<GetLanguageDetailsQuery>
    {
        public GetLanguageDetailsQueryValidator()
        {
            RuleFor(lang => lang.Id).NotEqual(Guid.Empty);
            RuleFor(lang => lang.UserId).NotEqual(Guid.Empty);
        }
    }
}
