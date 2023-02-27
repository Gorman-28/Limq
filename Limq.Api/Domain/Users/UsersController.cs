using Limq.Api.Common;
using Limq.Api.Domain.Users.Requests;
using Limq.Application.Domain.Users.Command.ChangeUser;
using Limq.Application.Domain.Users.Command.CheckUser;
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
    public async Task<GetUsersDto[]> GetUsers([FromQuery] string name, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery(name);
        var users = await _mediator.Send(query, cancellationToken);
        return users;
    }

    [HttpGet()]
    [Route("CheckUser")]
    public async Task<User> CheckUser([FromQuery] string name, CancellationToken cancellationToken)
    {
        var command = new CheckUserCommand(name);
        var user = await _mediator.Send(command, cancellationToken);
        return user;
    }

    [HttpGet()]
    [Route("GetUser")]

    public async Task<User> TakeUser([FromQuery] string name, string password, CancellationToken cancellationToken)
    {
        var command = new GetUserCommand(name, password);
        var user = await _mediator.Send(command, cancellationToken);
        return user;
    }

    [HttpPut()]
    [Route("ChangeAvatar")]

    public async Task<Unit> ChangeAvatar([FromForm] ChangeAvatarRequest request, CancellationToken cancellationToken)
    {
        byte[] imageData = null;
        if (request.Avatar != null)
        {
            using var binaryReader = new BinaryReader(request.Avatar.OpenReadStream());
            imageData = binaryReader.ReadBytes((int)request.Avatar.Length);
        }
        var command = new ChangeAvatarCommand(request.Id, imageData);
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

    [HttpPut()]
    [Route("ChangeStatus")]

    public async Task<Unit> ChangeStatus([FromBody] ChangeStatusRequest request, CancellationToken cancellationToken)
    {
        var command = new ChangeStatusCommand(request.Id, request.Status);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpPost()]
    [Route("CreateUser")]
    public async Task<Unit> CreateUser([FromForm] CreateUserRequest request, CancellationToken cancellationToken)
    {
        byte[] imageData = null;
        if (request.Avatar != null)
        {
            using var binaryReader = new BinaryReader(request.Avatar.OpenReadStream());
            imageData = binaryReader.ReadBytes((int)request.Avatar.Length);
        }
        var command = new CreateUserCommand(request.UserName, request.Password, request.FirstName, request.LastName, imageData);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpDelete()]
    [Route("RemoveUser")]

    public async Task<Unit> RemoveUser(Guid id, CancellationToken cancellationToken)
    {
        var command = new RemoveUserCommand(id);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }
}

