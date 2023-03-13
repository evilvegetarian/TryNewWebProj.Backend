using MediatR;

namespace TryNewWebProj.Application.Words.Queries.GetWordDetails
{
    public class GetWordDetailsQuery : IRequest<WordDetailsVM>
    {
        public Guid Id { get; set; }
    }

}
