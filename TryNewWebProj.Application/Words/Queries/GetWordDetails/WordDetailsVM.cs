using AutoMapper;
using TryNewWebProj.Application.Common.Mapping;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Words.Queries.GetWordDetails
{
    public class WordDetailsVM : IMapWith<Word>
    {
        public Guid Id { get; set; }
        public string WordValue { get; set; }
        public string Translate { get; set; }
        public DateTime CreationDate { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Word, WordDetailsVM>()
                .ForMember(word => word.WordValue, opt => opt.MapFrom(w => w.WordValue))
                .ForMember(word => word.Translate, opt => opt.MapFrom(w => w.Translate))
                .ForMember(word => word.CreationDate, opt => opt.MapFrom(w => w.CreationDate))
                .ForMember(word => word.Id, opt => opt.MapFrom(w => w.Id));
        }
    }
}
