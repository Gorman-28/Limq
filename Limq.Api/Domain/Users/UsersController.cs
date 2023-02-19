using Limq.Api.Common;
using Limq.Api.Domain.Users.Requests;
using Limq.Application.Domain.Users.Command.ChangeUser;
using Limq.Application.Domain.Users.Command.CreateUser;
using Limq.Application.Domain.Users.Command.GetUser;
using Limq.Application.Domain.Users.Command.RemoveUser;
using Limq.Application.Domain.Users.Queries.GetUsers;
using Limq.Core.Domain.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Limq.Api.Domain.Users;

[ApiController]
[Route(Routes.Users)]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    [Route("GetUsers")]
    public async Task<GetUsersDto[]> GetUsers([FromBody] string name, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery(name);
        var users = await _mediator.Send(query, cancellationToken);
        return users;
    }

    [HttpGet()]
    [Route("GetUser")]

    public async Task<User> TakeUser([FromBody] string name, CancellationToken cancellationToken)
    {
        var command = new GetUserCommand(name);
        var user = await _mediator.Send(command, cancellationToken);
        return user;
    }

    [HttpPut()]
    [Route("ChangeAvatar")]

    public async Task<Unit> ChangeAvatar([FromBody] ChangeAvatarRequest request, CancellationToken cancellationToken)
    {
        var command = new ChangeAvatarCommand(request.Id, request.Avatar);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpPut()]
    [Route("ChangeUserName")]

    public async Task<Unit> ChangeUserName([FromBody] ChangeUserNameRequest request, CancellationToken cancellationToken)
    {
        var command = new ChangeUserNameCommand(request.Id, request.NewUserName);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpPut()]
    [Route("ChangeFirstName")]

    public async Task<Unit> ChangeFirstName([FromBody] ChangeFirstNameRequest request, CancellationToken cancellationToken)
    {
        var command = new ChangeFirstNameCommand(request.Id, request.NewFirstName);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpPut()]
    [Route("ChangeLastName")]

    public async Task<Unit> ChangeLastName([FromBody] ChangeLastNameRequest request, CancellationToken cancellationToken)
    {
        var command = new ChangeLastNameCommand(request.Id, request.NewLastName);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpPut()]
    [Route("ChangePassword")]

    public async Task<Unit> ChangePassword([FromBody] ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        var command = new ChangePasswordCommand(request.Id, request.NewPassword);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpPost()]

    public async Task<Unit> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(request.UserName, request.Password, request.FirstName, request.LastName, request.Avatar);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpDelete()]

    public async Task<Unit> RemoveUser([FromBody] Guid id, CancellationToken cancellationToken)
    {
        var command = new RemoveUserCommand(id);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }
}

