using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TryNewWebProj.Application.Common.Mapping;
using TryNewWebProj.Application.Languages.Commands.CreateCommand;

namespace TryNewWebProj.WebAopi.Models.Language
{
    public class CreateLanguageDto : IMapWith<CreateLanguageCommand>
    {
        [Required]
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateLanguageDto, CreateLanguageCommand>()
                .ForMember(lang => lang.Title,
                    opt => opt.MapFrom(langDto => langDto.Title));
        }
    }
}
