using MediatR;

namespace TryNewWebProj.Application.Settings.Command.UpdateCommand
{
    public class UpdateAllSettingCommand : IRequest
    {
        public Guid UserId { get; set; }
    }
}
