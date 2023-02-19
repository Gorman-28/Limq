using MediatR;

namespace Limq.Application.Domain.Users.Queries.GetUsers;
public record GetUserQuery(string Name) : IRequest<GetUsersDto[]>;
