using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Application.Common.Exceptions;
using TryNewWebProj.Application.Interfaces;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Words.Queries.GetWordDetails
{
    public class GetWordDetailsQueryHandler : IRequestHandler<GetWordDetailsQuery, WordDetailsVM>
    {
        private readonly IWordDbContext dbContext;
        private readonly IMapper mapper;

        public GetWordDetailsQueryHandler(IWordDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<WordDetailsVM> Handle(GetWordDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Words
                .FirstOrDefaultAsync(dict => dict.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Word), request.Id);
            }
            return mapper.Map<WordDetailsVM>(entity);
        }
    }

}
