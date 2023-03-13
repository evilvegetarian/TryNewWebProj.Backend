using FluentValidation;

namespace TryNewWebProj.Application.Words.Queries.GetWordList
{
    public class GetWordListQueryValidator : AbstractValidator<GetWordListQuery>
    {
        public GetWordListQueryValidator()
        {
            RuleFor(x => x.LanguageId).NotEqual(Guid.Empty);
        }
    }
}
