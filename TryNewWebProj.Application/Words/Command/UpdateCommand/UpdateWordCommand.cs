using MediatR;

namespace TryNewWebProj.Application.Words.Command.UpdateCommand
{
    public class UpdateWordCommand : IRequest
    {
        public Guid LanguageId { get; set; }
        public Guid Id { get; set; }
        public string WordValue { get; set; }
        public string Translate { get; set; }
    }
}
