using MediatR;

namespace TryNewWebProj.Application.Settings.Command.UpdateCommand
{
    public class UpdateSettingLearnCommand : IRequest
    {
        public Guid WordId { get; set; }
        public bool Learn { get; set; }
    }
}
