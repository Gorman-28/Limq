namespace Limq.Api.Domain.Users.Requests;


public record CreateUserRequest(string UserName, string Password, string FirstName, string LastName, IFormFile Avatar);
