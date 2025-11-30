using Microsoft.Xna.Framework;
using Terraria;
using TShockAPI;

namespace AQuestHelper.Commands;

public class ShowQuest : Models.Command
{
    public override bool AllowServer => base.AllowServer;
    public override string[] Aliases { get; set; } = PluginSettings.Config.CommandAliases;
    public override string PermissionNode { get; set; } = "";

    public override void Execute(CommandArgs args)
    {
        TSPlayer player = args.Player;
        int completedQuests = player.TPlayer.anglerQuestsFinished;
        int currentFishNetId = Main.anglerQuestItemNetIDs[Main.anglerQuest];
        string currentFishName = Lang.GetItemNameValue(currentFishNetId);
        string currentFishLocation = Variables.FishLocation[currentFishNetId];
        bool done = Main.anglerWhoFinishedToday.Contains(player.Name);

        player.SendMessage(
            $"\nQuest({(done ? "[c/32FF82:Finished]" : "[c/FFF014:Unfinished]")}) - [i/s1:{currentFishNetId}] [c/FFA500:{currentFishName}]\nCaught in {currentFishLocation}\nCompleted Quests - [c/32FF82:{completedQuests}]",
            Color.AliceBlue
        );
    }
}
