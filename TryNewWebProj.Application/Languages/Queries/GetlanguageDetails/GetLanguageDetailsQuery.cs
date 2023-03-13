using MediatR;

namespace TryNewWebProj.Application.Languages.Queries.GetlanguageDetails
{
    public class GetLanguageDetailsQuery : IRequest<LanguageDetailsVM>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
