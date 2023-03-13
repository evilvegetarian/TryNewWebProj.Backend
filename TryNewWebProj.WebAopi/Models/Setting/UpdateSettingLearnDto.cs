using AutoMapper;
using TryNewWebProj.Application.Common.Mapping;
using TryNewWebProj.Application.Settings.Command.UpdateCommand;

namespace TryNewWebProj.WebAopi.Models.Setting
{
    public class UpdateSettingLearnDto : IMapWith<UpdateSettingLearnCommand>
    {
        public Guid WordId { get; set; }
        public bool Learn { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSettingLearnDto, UpdateSettingLearnCommand>()
                .ForMember(sett => sett.Learn, opt => opt.MapFrom(s => s.Learn))
                .ForMember(sett => sett.WordId, opt => opt.MapFrom(s => s.WordId));
        }
    }
}
