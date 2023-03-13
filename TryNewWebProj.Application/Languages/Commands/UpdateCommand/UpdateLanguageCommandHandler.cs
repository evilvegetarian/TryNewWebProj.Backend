using MediatR;
using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Application.Common.Exceptions;
using TryNewWebProj.Application.Interfaces;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Languages.Commands.UpdateCommand
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand>
    {
        private readonly IWordDbContext dbContext;

        public UpdateLanguageCommandHandler(IWordDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Languages
                .FirstOrDefaultAsync(lang => lang.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Language), request.Id);
            }
            entity.Title = request.Title;
            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }


    }
}
