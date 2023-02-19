using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Application.Domain.Users.Command.GetUser;
public record GetUserCommand(string Name) : IRequest<User>;
