using AutoMapper;
using TryNewWebProj.Application.Common.Mapping;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Languages.Queries.GetLanguageList
{
    public class LanguageLookUpDto : IMapWith<Language>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Language, LanguageLookUpDto>()
                .ForMember(lang => lang.Id, opt => opt.MapFrom(l => l.Id))
                .ForMember(lang => lang.Title, opt => opt.MapFrom(l => l.Title));
        }
    }
}
