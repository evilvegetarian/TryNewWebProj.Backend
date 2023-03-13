using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Application.Interfaces;

namespace TryNewWebProj.Application.Words.Queries.GetWordList
{
    public class GetWordListQueryHandler : IRequestHandler<GetWordListQuery, WordListVm>
    {
        private readonly IWordDbContext dbContext;
        private readonly IMapper mapper;

        public GetWordListQueryHandler(IWordDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<WordListVm> Handle(GetWordListQuery request, CancellationToken cancellationToken)
        {
            var dictQuery = await dbContext.Words
                .Where(dict => dict.LanguageId == request.LanguageId)
                .ProjectTo<WordLookUpDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new WordListVm { Words = dictQuery };
        }
    }
}
