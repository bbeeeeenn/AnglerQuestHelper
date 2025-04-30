using AQuestHelper.Commands;
using AQuestHelper.Models;

namespace AQuestHelper;

public class CommandManager
{
    public static readonly List<Command> Commands = new()
    {
        // Commands
        new ShowQuest(),
    };

    public static void RegisterAll()
    {
        foreach (Command command in Commands)
        {
            TShockAPI.Commands.ChatCommands.Add(command);
        }
    }
}
