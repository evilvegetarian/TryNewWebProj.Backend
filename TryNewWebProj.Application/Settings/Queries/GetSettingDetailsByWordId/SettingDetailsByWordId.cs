using AutoMapper;
using TryNewWebProj.Application.Common.Mapping;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Settings.Queries.GetSettingDetailsByWordId
{
    public class SettingDetailsByWordId : IMapWith<SettingsWord>
    {
        public Guid Id { get; set; }
        public int? ProcentLearning { get; set; }
        public int? Stage { get; set; }
        public int? StagePoint { get; set; }
        public int? StagePointBall { get; set; }
        public DateTime? LastTreaning { get; set; }
        public DateTime CreationDate { get; set; }
        public int Difficult { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SettingsWord, SettingDetailsByWordId>()
                .ForMember(x => x.LastTreaning, opt => opt.MapFrom(u => u.LastTreaning))
                .ForMember(x => x.CreationDate, opt => opt.MapFrom(u => u.CreationDate))
                .ForMember(x => x.Difficult, opt => opt.MapFrom(u => u.Difficult))
                .ForMember(x => x.StagePointBall, opt => opt.MapFrom(u => u.StagePointBall))
                .ForMember(x => x.StagePoint, opt => opt.MapFrom(u => u.StagePoint))
                .ForMember(x => x.Stage, opt => opt.MapFrom(u => u.Stage))
                .ForMember(x => x.Id, opt => opt.MapFrom(u => u.Id))
                .ForMember(x => x.ProcentLearning, opt => opt.MapFrom(u => u.ProcentLearning));
        }
    }
}
