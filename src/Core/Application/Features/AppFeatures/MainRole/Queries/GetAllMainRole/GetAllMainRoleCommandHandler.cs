using System;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.MainRole.Queries.GetAllMainRole
{
    public class GetAllMainRoleCommandHandler : ICommandHandler<GetAllMainRoleCommand, GetAllMainRoleCommandResponse>
    {
        private readonly IMainRoleService _mainRoleService;

        public GetAllMainRoleCommandHandler(IMainRoleService mainRoleService)
        {
            _mainRoleService = mainRoleService;
        }

        public async Task<GetAllMainRoleCommandResponse> Handle(GetAllMainRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _mainRoleService.GetMainRoleAsync();
            var mainRoleDto = result.Select(s => new MainRoleDto(s.Id,s.Title)).ToList();
            return new(result.Count(), mainRoleDto);
        }
    }
}

