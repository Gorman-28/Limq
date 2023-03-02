namespace Limq.Api.Domain.MessagesSquad.Requests;

public record CreateMessageSquadRequest(Guid SquadId, Guid UserFromId, string Message, DateTime MessageTime, bool SystemMessage);
