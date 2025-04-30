using Microsoft.Xna.Framework;
using Terraria;
using TShockAPI;

namespace AQuestHelper.Commands;

public class ShowQuest : Models.Command
{
    public override bool AllowServer => base.AllowServer;
    public override string[] Aliases { get; set; } = PluginSettings.Config.CommandAliases;
    public override string PermissionNode { get; set; } = "";

    public static readonly Dictionary<int, string> FishLocation = new()
    {
        { 2475, "Glowing Mushroom Fields" },
        { 2476, "Sky Lakes" },
        { 2450, "Underground & Caverns" },
        { 2477, "Crimson" },
        { 2478, "Underground & Caverns" },
        { 2451, "Honey" },
        { 2479, "Surface" },
        { 2480, "Ocean" },
        { 2452, "Jungle Surface" },
        { 2453, "Sky Lakes" },
        { 2481, "Ocean" },
        { 2454, "Corruption" },
        { 2482, "Caverns" },
        { 2483, "Jungle Surface" },
        { 2455, "Surface & Underground" },
        { 2456, "Surface" },
        { 2457, "Corruption" },
        { 2458, "Sky Lakes & Surface" },
        { 2459, "Sky Lakes & Surface" },
        { 2460, "Caverns" },
        { 2484, "Underground Tundra" },
        { 2472, "Caverns" },
        { 2461, "Sky Lakes & Surface" },
        { 2462, "Caverns" },
        { 2463, "Crimson" },
        { 2485, "Corruption" },
        { 2464, "Underground & Caverns" },
        { 2465, "Underground Hallow" },
        { 2486, "Jungle" },
        { 2466, "Underground Tundra" },
        { 2467, "Surface Tundra" },
        { 2468, "Surface Hallow" },
        { 2493, "Desert" },
        { 2494, "Desert" },
        { 2487, "Surface Forest" },
        { 2469, "Underground & Caverns" },
        { 2488, "Jungle Surface" },
        { 2470, "Surface Tundra" },
        { 2471, "Hallow" },
        { 2473, "Sky Lakes" },
        { 2474, "Surface" },
    };

    public override void Execute(CommandArgs args)
    {
        TSPlayer player = args.Player;
        int completedQuests = player.TPlayer.anglerQuestsFinished;
        int currentFishNetId = Main.anglerQuestItemNetIDs[Main.anglerQuest];
        string currentFishName = Lang.GetItemNameValue(currentFishNetId);
        string currentFishLocation = FishLocation[currentFishNetId];
        bool done = Main.anglerWhoFinishedToday.Contains(player.Name);

        player.SendMessage(
            $"Quest({(done ? "[c/32FF82:Finished]" : "[c/FFF014:Unfinished]")}) - [i/s1:{currentFishNetId}] [c/FFA500:{currentFishName}]\nCaught in {currentFishLocation}\nCompleted Quests - [c/32FF82:{completedQuests}]",
            Color.AliceBlue
        );
    }
}
