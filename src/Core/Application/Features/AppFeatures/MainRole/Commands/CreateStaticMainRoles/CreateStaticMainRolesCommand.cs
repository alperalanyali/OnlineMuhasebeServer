using System;
using Application.Messaging;
namespace Application.Features.AppFeatures.MainRole.Commands.CreateStaticMainRoles
{
    public record CreateStaticMainRolesCommand(
        //List<Domain.AppEntities.MainRole> MainRoles

        ) : ICommand<CreateStaticMainRolesResponse>
    {
     
    }
}

