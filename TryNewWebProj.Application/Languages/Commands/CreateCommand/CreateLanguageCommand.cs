using MediatR;

namespace TryNewWebProj.Application.Languages.Commands.CreateCommand
{
    public class CreateLanguageCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
    }
}
