﻿using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using StoreApi;

namespace Store_TestModule;

public class Store_TestModule : BasePlugin
{
    public override string ModuleName { get; } = "Store Module [Test]";
    public override string ModuleVersion { get; } = "0.0.1";

    public override void OnAllPluginsLoaded(bool hotReload)
    {
        IStoreApi? storeApi = IStoreApi.Capability.Get();

        if (storeApi == null)
        {
            return;
        }

        /*
         * Type
         * OnMapStart
         * Equip
         * Unequip
         * Equipable (If the item is equipable make this true, if not make it false.)
         * Alive (If the item is equipable, make it null. If not, make it true if it can be picked up alive, false if it can be picked up dead, or null if it doesn't matter.)
        */
        storeApi.RegisterType("test", OnMapStart, Equip, Unequip, true, true);
    }

    public static void OnMapStart()
    {
    }

    public static bool Equip(CCSPlayerController player, Dictionary<string, string> item)
    {
        Server.PrintToChatAll($"Player {player.PlayerName} equipped {item["Name"]}");
        return true;
    }

    public static bool Unequip(CCSPlayerController player, Dictionary<string, string> item)
    {
        Server.PrintToChatAll($"Player {player.PlayerName} unequipped {item["Name"]}");
        return true;
    }
}