using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Application.Domain.Users.Command.CheckUser;
public record CheckUserCommand(string Name) : IRequest<User>;
