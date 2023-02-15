﻿using Limq.Application.Domain.Users.Queries.GetUsers;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.Users.Queries.GetUsers;
public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersDto[]>
{
    private readonly LimqDbContext _limqDbContext;

    public GetUsersQueryHandler(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<GetUsersDto[]> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var sqlquery = _limqDbContext.Users.AsNoTracking();
        var data = await sqlquery
            .Where(u => u.UserName == request.Name)
            .OrderBy(u => u.UserName)
            .Select(user => new GetUsersDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status,
                Avatar = user.Avatar
            }).ToArrayAsync(cancellationToken);

        return data;
    }
}
