using AQuestHelper.Events;
using AQuestHelper.Models;
using TerrariaApi.Server;

namespace AQuestHelper;

public class EventManager
{
    public static readonly List<Event> events = new()
    {
        // Events
        new OnReload(),
        new OnGameUpdate(),
    };

    public static void RegisterAll(TerrariaPlugin plugin)
    {
        foreach (Event _event in events)
        {
            _event.Enable(plugin);
        }
    }

    public static void DeregisterAll(TerrariaPlugin plugin)
    {
        foreach (Event _event in events)
        {
            _event.Disable(plugin);
        }
    }
}
