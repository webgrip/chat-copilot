using System;
using System.Collections.Generic;
using CopilotChat.WebApi.Services;
using CopilotChat.WebApi.Services.MemoryMigration;
using Microsoft.Extensions.DependencyInjection;

namespace CopilotChat.WebApi.Factories;

public class MaintenanceActionFactory : IMaintenanceActionFactory
{
    private readonly IServiceProvider _serviceProvider;

    public MaintenanceActionFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IReadOnlyList<IMaintenanceAction> CreateActions()
    {
        using var scope = _serviceProvider.CreateScope();
        return new[]
        {
            scope.ServiceProvider.GetRequiredService<ChatMigrationMaintenanceAction>(),
        };
    }
}