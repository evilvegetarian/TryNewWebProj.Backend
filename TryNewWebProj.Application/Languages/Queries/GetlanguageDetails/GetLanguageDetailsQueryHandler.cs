using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Application.Common.Exceptions;
using TryNewWebProj.Application.Interfaces;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Languages.Queries.GetlanguageDetails
{
    public class GetLanguageDetailsQueryHandler : IRequestHandler<GetLanguageDetailsQuery, LanguageDetailsVM>
    {
        private readonly IWordDbContext dbContext;
        private readonly IMapper mapper;

        public GetLanguageDetailsQueryHandler(IWordDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<LanguageDetailsVM> Handle(GetLanguageDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Languages
                .FirstOrDefaultAsync(lang => lang.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Language), request.Id);
            }
            return mapper.Map<LanguageDetailsVM>(entity);
        }
    }
}
