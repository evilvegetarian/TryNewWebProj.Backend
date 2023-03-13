using MediatR;
using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Application.Interfaces;

namespace TryNewWebProj.Application.Settings.Command.UpdateCommand
{
    public class UpdateSettingLearnCommandHandler : IRequestHandler<UpdateSettingLearnCommand>
    {
        private readonly IWordDbContext dbContext;

        public UpdateSettingLearnCommandHandler(IWordDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateSettingLearnCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.SettingsWords
                .FirstOrDefaultAsync(sett => sett.WordId == request.WordId, cancellationToken);

            entity.LastTreaning = DateTime.Now;
            if (request.Learn)
            {
                entity.StagePointBall += 1;
                entity.ProcentLearning += entity.Difficult;
            }
            else
            {
                entity.StagePoint += 1;
                entity.ProcentLearning -= entity.Difficult;
            }

            if (entity.StagePointBall / entity.StagePoint == 1)
            {
                entity.Stage += 1;
                entity.StagePoint = entity.StagePoint * 8 / 5;
            }

            await dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }


}
