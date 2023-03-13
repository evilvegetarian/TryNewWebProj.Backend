using MediatR;
using TryNewWebProj.Application.Interfaces;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Languages.Commands.CreateCommand
{
    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, Guid>
    {
        private readonly IWordDbContext dbContext;

        public CreateLanguageCommandHandler(IWordDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            var lang = new Language
            {
                Title = request.Title,
                UserId = request.UserId,
                CreationDate = DateTime.Now,
                Id = Guid.NewGuid()
            };

            await dbContext.Languages.AddAsync(lang, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return lang.Id;
        }
    }
}
