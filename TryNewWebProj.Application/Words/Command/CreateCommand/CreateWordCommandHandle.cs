using MediatR;
using TryNewWebProj.Application.Interfaces;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Words.Command.CreateCommand
{
    public class CreateWordCommandHandle : IRequestHandler<CreateWordCommand, Guid>
    {
        private readonly IWordDbContext dbContext;

        public CreateWordCommandHandle(IWordDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateWordCommand request, CancellationToken cancellationToken)
        {
            var dict = new Word
            {
                LanguageId = request.LanguageId,
                WordValue = request.WordValue,
                Translate = request.Translate,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now
            };

            var sett = new SettingsWord
            {
                WordId = dict.Id,
                Id = Guid.NewGuid()
            };

            await dbContext.SettingsWords.AddAsync(sett);
            await dbContext.Words.AddAsync(dict);
            await dbContext.SaveChangesAsync(cancellationToken);
            return dict.Id;
        }
    }
}
