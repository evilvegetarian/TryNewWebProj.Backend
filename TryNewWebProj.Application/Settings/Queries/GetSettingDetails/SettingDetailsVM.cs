using AutoMapper;
using TryNewWebProj.Application.Common.Mapping;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Settings.Queries.GetSettingDetails
{
    public class SettingDetailsVM : IMapWith<SettingsWord>
    {
        public Guid Id { get; set; }
        public int? ProcentLearning { get; set; }
        public int? Stage { get; set; }
        public DateTime? LastTreaning { get; set; }
        public int Difficult { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SettingsWord, SettingDetailsVM>()
                .ForMember(sett=>sett.Id,opt=>opt.MapFrom(x=>x.Id))
                .ForMember(sett=>sett.ProcentLearning, opt=>opt.MapFrom(x=>x.ProcentLearning))
                .ForMember(sett=>sett.Stage, opt=>opt.MapFrom(x=>x.Stage))
                .ForMember(sett=>sett.LastTreaning, opt=>opt.MapFrom(x=>x.LastTreaning))
                .ForMember(sett=>sett.Difficult, opt=>opt.MapFrom(x=>x.Difficult));
        }
    }
}
