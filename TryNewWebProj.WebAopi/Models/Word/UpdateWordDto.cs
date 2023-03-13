using AutoMapper;
using TryNewWebProj.Application.Common.Mapping;
using TryNewWebProj.Application.Words.Command.UpdateCommand;

namespace TryNewWebProj.WebAopi.Models.Word
{
    public class UpdateWordDto : IMapWith<UpdateWordCommand>
    {
        public Guid Id { get; set; }
        public string WordValue { get; set; }
        public string Translate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateWordDto, UpdateWordCommand>()
                .ForMember(dict => dict.Id, opt => opt.MapFrom(dictDto => dictDto.Id))
                .ForMember(dict => dict.Translate, opt => opt.MapFrom(dictDto => dictDto.Translate))
                .ForMember(dict => dict.WordValue, opt => opt.MapFrom(dictDto => dictDto.WordValue));
        }
    }
}
