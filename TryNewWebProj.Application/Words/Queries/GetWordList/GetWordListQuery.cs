using MediatR;

namespace TryNewWebProj.Application.Words.Queries.GetWordList
{
    public class GetWordListQuery : IRequest<WordListVm>
    {
        public Guid LanguageId { get; set; }
    }
}
