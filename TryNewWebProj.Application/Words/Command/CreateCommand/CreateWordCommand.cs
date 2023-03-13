using MediatR;

namespace TryNewWebProj.Application.Words.Command.CreateCommand
{
    public class CreateWordCommand : IRequest<Guid>
    {
        public Guid LanguageId { get; set; }
        public string WordValue { get; set; }
        public string Translate { get; set; }
    }
}
