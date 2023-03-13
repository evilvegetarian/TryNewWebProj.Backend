using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Application.Interfaces;

namespace TryNewWebProj.Application.Languages.Queries.GetLanguageList
{
    public class GetLanguageListQueryhandler : IRequestHandler<GetLanguageListQuery, LanguageListVm>
    {
        private readonly IMapper mapper;
        private readonly IWordDbContext dbContext;

        public GetLanguageListQueryhandler(IMapper mapper, IWordDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<LanguageListVm> Handle(GetLanguageListQuery request, CancellationToken cancellationToken)
        {
            var langQuery = await dbContext.Languages
                .Where(lang => lang.UserId == request.UserId)
                .ProjectTo<LanguageLookUpDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new LanguageListVm { Languages = langQuery };
        }
    }
}
