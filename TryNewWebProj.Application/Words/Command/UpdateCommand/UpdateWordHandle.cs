using MediatR;
using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Application.Common.Exceptions;
using TryNewWebProj.Application.Interfaces;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Words.Command.UpdateCommand
{
    public class UpdateWordHandle : IRequestHandler<UpdateWordCommand>
    {
        private readonly IWordDbContext dbContext;

        public UpdateWordHandle(IWordDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateWordCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Words
                .FirstOrDefaultAsync(dict => dict.Id == request.Id, cancellationToken);

            if (entity == null || entity.LanguageId != request.LanguageId)
            {
                throw new NotFoundException(nameof(Language), request.Id);
            }
            entity.WordValue = request.WordValue;
            entity.LanguageId = request.LanguageId;
            entity.Translate = request.Translate;
            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
