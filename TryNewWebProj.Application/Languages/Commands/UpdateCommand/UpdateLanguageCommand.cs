using MediatR;

namespace TryNewWebProj.Application.Languages.Commands.UpdateCommand
{
    public class UpdateLanguageCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
