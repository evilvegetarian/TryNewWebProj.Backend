using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Application.Common.Exceptions;
using TryNewWebProj.Application.Interfaces;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Settings.Queries.GetSettingDetailsByWordId
{
    public class GetSettingDetailsByWordIdQueryHandler : IRequestHandler<GetSettingDetailsByWordIdQuery, SettingDetailsByWordId>
    {
        private readonly IMapper mapper;
        private readonly IWordDbContext dbContext;

        public GetSettingDetailsByWordIdQueryHandler(IMapper mapper, IWordDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<SettingDetailsByWordId> Handle(GetSettingDetailsByWordIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.SettingsWords
                .FirstOrDefaultAsync(sett => sett.WordId == request.WordId, cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(SettingsWord), entity.Id);

            return mapper.Map<SettingDetailsByWordId>(entity);
        }
    }
}
