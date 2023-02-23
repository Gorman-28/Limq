using Limq.Core.Common;
using Limq.Core.Domain.Chats.Common;
using Limq.Core.Domain.Messages.Common;
using Limq.Core.Domain.Squads.Common;
using Limq.Core.Domain.Users.Common;
using Limq.Infastructure.Core.Common;
using Limq.Infastructure.Core.Domain.Chats.Common;
using Limq.Infastructure.Core.Domain.MessagesChat.Common;
using Limq.Infastructure.Core.Domain.MessagesSquad.Common;
using Limq.Infastructure.Core.Domain.Squads.Common;
using Limq.Infastructure.Core.Domain.UserChatsBlocked.Common;
using Limq.Infastructure.Core.Domain.Users.Common;
using Limq.Infastructure.Core.Domain.UserSquads.Common;
using Limq.Infastructure.Core.Domain.UserSquadsBlocked.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Limq.Infastructure;
public static class InfastructureRegistration
{
    public static void AddInfastructureServices(this IServiceCollection services)
    {
        //MediatR

        services.AddMediatR(typeof(InfastructureRegistration));


        //UnitOfWork

        services.AddScoped<IUnitOfWork, UnitOfWork>();


        //Repositories

        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IUserSquadRepository, UserSquadRepository>();
        services.AddSingleton<IUserChatBlockedRepository, UserChatBlockedRepository>();
        services.AddSingleton<IUserSquadBlockedRepository, UserSquadBlockedRepository>();
        services.AddSingleton<IChatRepository, ChatRepository>();
        services.AddSingleton<IMessageChatRepository, MessageChatRepository>();
        services.AddSingleton<IMessageSquadRepository, MessageSquadRepository>();
        services.AddSingleton<ISquadRepository, SquadRepository>();
    }
}
