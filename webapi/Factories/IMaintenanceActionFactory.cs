using System.Collections.Generic;
using CopilotChat.WebApi.Services;

namespace CopilotChat.WebApi.Factories;

public interface IMaintenanceActionFactory
{
    IReadOnlyList<IMaintenanceAction> CreateActions();
}