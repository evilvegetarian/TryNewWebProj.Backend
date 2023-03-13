using FluentValidation;

namespace TryNewWebProj.Application.Words.Queries.GetWordDetails
{
    public class GetWordDetailsQueryValidator : AbstractValidator<GetWordDetailsQuery>
    {
        public GetWordDetailsQueryValidator()
        {
            RuleFor(dict => dict.Id).NotEmpty();
        }
    }

}
