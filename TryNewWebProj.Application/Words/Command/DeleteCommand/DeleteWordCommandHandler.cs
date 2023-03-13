using MediatR;
using TryNewWebProj.Application.Common.Exceptions;
using TryNewWebProj.Application.Interfaces;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Words.Command.DeleteCommand
{
    public class DeleteWordCommandHandler : IRequestHandler<DeleteWordCommand>
    {
        private readonly IWordDbContext dbContext;

        public DeleteWordCommandHandler(IWordDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteWordCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Words
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Word), request.Id);
            }

            dbContext.Words.Remove(entity);
            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
