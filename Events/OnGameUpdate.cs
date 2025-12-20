using AQuestHelper.Models;
using Microsoft.Xna.Framework;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using TShockAPI.Hooks;

namespace AQuestHelper.Events;

public class OnGameUpdate : Event
{
    private bool lastDayTime = Main.dayTime;

    public override void Disable(TerrariaPlugin plugin)
    {
        ServerApi.Hooks.GamePostUpdate.Deregister(plugin, EventMethod);
    }

    public override void Enable(TerrariaPlugin plugin)
    {
        ServerApi.Hooks.GamePostUpdate.Register(plugin, EventMethod);
    }

    private void EventMethod(EventArgs e)
    {
        // Detect sunrise
        if (Main.dayTime && !lastDayTime && Main.time == 0)
        {
            if (!NPC.savedAngler)
            {
                return;
            }
            int currentFishNetId = Main.anglerQuestItemNetIDs[Main.anglerQuest];
            string currentFishName = Lang.GetItemNameValue(currentFishNetId);
            string currentFishLocation = Variables.FishLocation[currentFishNetId];
            string notificationString = string.Format(
                PluginSettings.Config.NewQuestNotificationFormat,
                $"[i/s1:{currentFishNetId}]",
                $"[c/FFA500:{currentFishName}]",
                currentFishLocation
            );
            TShock.Utils.Broadcast(notificationString, Color.AliceBlue);
            foreach (TSPlayer player in TShock.Players)
            {
                if (player != null && player.Active)
                {
                    player.SendMessage(
                        $"Completed Quests - [c/32FF82:{player.TPlayer.anglerQuestsFinished}]",
                        Color.AliceBlue
                    );
                }
            }
        }

        lastDayTime = Main.dayTime;
    }
}
