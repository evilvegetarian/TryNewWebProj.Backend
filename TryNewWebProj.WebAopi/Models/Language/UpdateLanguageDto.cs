using AutoMapper;
using TryNewWebProj.Application.Common.Mapping;
using TryNewWebProj.Application.Languages.Commands.UpdateCommand;

namespace TryNewWebProj.WebAopi.Models.Language
{
    public class UpdateLanguageDto : IMapWith<UpdateLanguageCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateLanguageDto, UpdateLanguageCommand>()
                .ForMember(lang => lang.Id,
                    opt => opt.MapFrom(langDto => langDto.Id))
                .ForMember(lang => lang.Title,
                    opt => opt.MapFrom(langDto => langDto.Title));

        }
    }
}
