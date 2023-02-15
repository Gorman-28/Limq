using MediatR;

namespace Limq.Application.Domain.Users.Queries.GetUsers;
public record GetUsersQuery(string Name) : IRequest<GetUsersDto[]>;
