using MediatR;

namespace TryNewWebProj.Application.Languages.Commands.DeleteCommand
{
    public class DeleteLanguageCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
