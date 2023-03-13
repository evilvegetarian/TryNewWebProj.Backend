using MediatR;

namespace TryNewWebProj.Application.Settings.Queries.GetSettingDetailsByWordId
{
    public class GetSettingDetailsByWordIdQuery : IRequest<SettingDetailsByWordId>
    {
        public Guid WordId { get; set; }
    }
}
