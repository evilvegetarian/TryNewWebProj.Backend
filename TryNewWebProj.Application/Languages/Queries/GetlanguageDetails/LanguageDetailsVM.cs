using AutoMapper;
using TryNewWebProj.Application.Common.Mapping;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Languages.Queries.GetlanguageDetails
{
    public class LanguageDetailsVM : IMapWith<Language>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Language, LanguageDetailsVM>()
                .ForMember(lang => lang.Title, opt => opt.MapFrom(l => l.Title))
                .ForMember(lang => lang.CreationDate, opt => opt.MapFrom(l => l.CreationDate))
                .ForMember(lang => lang.Id, opt => opt.MapFrom(l => l.Id));
        }
    }
}
