using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Application.Interfaces;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Settings.Command.UpdateCommand
{
    public class UpdateAllSettingCommandHandler : IRequestHandler<UpdateAllSettingCommand>
    {
        private readonly IWordDbContext dbContext;

        public UpdateAllSettingCommandHandler(IWordDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateAllSettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Languages
                .Where(lang => lang.UserId == request.UserId).ToListAsync();

            List<Word> words = new List<Word>();
            foreach (var lang in entity)
            {
                var ss = await dbContext.Words.Where(x => x.LanguageId == lang.Id).ToListAsync();
                words.AddRange(ss);
            }
            List<SettingsWord> allsetts = new List<SettingsWord>();
            foreach (var word in words)
            {
                var ss = await dbContext.SettingsWords.Where(x => x.WordId == word.Id).ToListAsync();
                allsetts.AddRange(ss);
            }

            foreach (var settings in allsetts)
            {
                TimeSpan date = DateTime.Now.Subtract(settings.LastTreaning.Value);

                //7 дней не было занятий, 7/3=2
                var dateStage1 = date.Days / 3;
                var dateStage2 = date.Days / 6;
                var dateStage3 = date.Days / 12;
                if (date.Days >= 3)
                {
                    if (settings.Stage == 1)
                    {
                        settings.ProcentLearning -= 3 * dateStage1;
                        var lastTren = settings.LastTreaning.Value;
                        settings.LastTreaning = lastTren.AddDays(dateStage1 * 3);
                    }

                    else if (settings.Stage == 2)
                    {
                        settings.ProcentLearning -= 2 * dateStage1;
                        var lastTren = settings.LastTreaning.Value;
                        settings.LastTreaning = lastTren.AddDays(dateStage1 * 3);
                    }

                    else if (settings.Stage == 3)
                    {
                        settings.ProcentLearning -= 1 * dateStage1;
                        var lastTren = settings.LastTreaning.Value;
                        settings.LastTreaning = lastTren.AddDays(dateStage1 * 3);
                    }

                    if (date.Days >= 6 && settings.Stage == 4)
                    {
                        settings.ProcentLearning -= 1 * dateStage2;
                        var lastTren = settings.LastTreaning.Value;
                        settings.LastTreaning = lastTren.AddDays(dateStage2 * 6);
                    }

                    if (date.Days >= 12 && settings.Stage == 5)
                    {
                        settings.ProcentLearning -= 1 * dateStage3;
                        var lastTren = settings.LastTreaning.Value;
                        settings.LastTreaning = lastTren.AddDays(dateStage3 * 12);
                    }
                }

                dbContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
