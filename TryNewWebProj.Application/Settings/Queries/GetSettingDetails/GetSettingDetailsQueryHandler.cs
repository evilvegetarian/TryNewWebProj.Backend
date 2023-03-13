using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Application.Common.Exceptions;
using TryNewWebProj.Application.Interfaces;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Settings.Queries.GetSettingDetails
{
    public class GetSettingDetailsQueryHandler : IRequestHandler<GetSettingDetailsQuery, SettingDetailsVM>
    {
        private readonly IMapper mapper;
        private readonly IWordDbContext dbContext;

        public GetSettingDetailsQueryHandler(IMapper mapper, IWordDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<SettingDetailsVM> Handle(GetSettingDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.SettingsWords
                    .FirstOrDefaultAsync(sett => sett.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(SettingsWord), request.Id);

            return mapper.Map<SettingDetailsVM>(entity);
        }
    }
}
