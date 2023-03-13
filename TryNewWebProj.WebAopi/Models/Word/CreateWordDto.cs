using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TryNewWebProj.Application.Common.Mapping;
using TryNewWebProj.Application.Words.Command.CreateCommand;

namespace TryNewWebProj.WebAopi.Models.Word
{
    public class CreateWordDto : IMapWith<CreateWordCommand>
    {
        [Required]
        public string WordValue { get; set; }
        public string Translate { get; set; }
        public Guid LanguageId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateWordDto, CreateWordCommand>()
                .ForMember(dict => dict.WordValue, opt => opt.MapFrom(dictDto => dictDto.WordValue))
                .ForMember(dict => dict.Translate, opt => opt.MapFrom(dictDto => dictDto.Translate))
                .ForMember(dict => dict.LanguageId, opt => opt.MapFrom(dictDto => dictDto.LanguageId));
        }
    }
}
