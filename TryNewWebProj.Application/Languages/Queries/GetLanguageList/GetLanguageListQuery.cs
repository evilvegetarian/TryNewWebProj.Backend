using MediatR;

namespace TryNewWebProj.Application.Languages.Queries.GetLanguageList
{
    public class GetLanguageListQuery : IRequest<LanguageListVm>
    {
        public Guid UserId { get; set; }
    }
}
