using FluentValidation;

namespace TryNewWebProj.Application.Languages.Queries.GetLanguageList
{
    public class GetLanguageListQueryValidator : AbstractValidator<GetLanguageListQuery>
    {
        public GetLanguageListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
