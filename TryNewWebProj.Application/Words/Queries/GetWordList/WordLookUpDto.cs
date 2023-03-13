using AutoMapper;
using TryNewWebProj.Application.Common.Mapping;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Words.Queries.GetWordList
{
    public class WordLookUpDto : IMapWith<Word>
    {
        public Guid Id { get; set; }
        public string WordValue { get; set; }
        public string Translate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Word, WordLookUpDto>()
                .ForMember(lang => lang.WordValue, opt => opt.MapFrom(l => l.WordValue))
                .ForMember(lang => lang.Translate, opt => opt.MapFrom(l => l.Translate))
                .ForMember(lang => lang.Id, opt => opt.MapFrom(l => l.Id));
        }
    }
}