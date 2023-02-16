using Limq.Application.Domain.UsersSquad.Queries.GetUsersSquad;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.UserSquads.Queries.GetUsersSquad;
public class GetUsersSquadQueryHandler : IRequestHandler<GetUsersSquadQuery, GetUsersSquadDto[]>
{
    private readonly LimqDbContext _limqDbContext;

    public GetUsersSquadQueryHandler(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<GetUsersSquadDto[]> Handle(GetUsersSquadQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = from us in _limqDbContext.UserSquads.Where(us => us.SquadId == request.SquadId)
                       join u in _limqDbContext.Users on us.UserId equals u.Id
                       select new GetUsersSquadDto
                       {
                           Id = u.Id,
                           UserName = u.UserName,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Avatar = u.Avatar,
                           Status = u.Status,
                       };

        var data = await sqlQuery
            .AsNoTracking()
            .OrderBy(u => u.UserName)
            .ToArrayAsync(cancellationToken);

        return data;
    }
}
