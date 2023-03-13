using MediatR;

namespace TryNewWebProj.Application.Settings.Queries.GetSettingDetails
{
    public class GetSettingDetailsQuery : IRequest<SettingDetailsVM>
    {
        public Guid Id { get; set; }
    }
}
