using MediatR;

namespace TryNewWebProj.Application.Words.Command.DeleteCommand
{
    public class DeleteWordCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
    }
}
