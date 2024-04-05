﻿using BepInEx;
using BepInEx.Logging;
using CupAPI.Content;
using CupAPI.Util;
using CupAPI.Utility;
using HarmonyLib;

namespace CupAPI {
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    internal class CupAPI : BaseUnityPlugin {

        public static readonly Harmony Harmony = new(PluginInfo.PLUGIN_GUID);
        public static new ManualLogSource Logger;

        private void Awake() {
            Harmony.PatchAll(); Logger = base.Logger;
            Logger.LogInfo($"CupAPI v{PluginInfo.PLUGIN_VERSION} was initialized!");
            CustomData.Initialize();

            EnumManager.Register<Charm>();
            if (EnumManager.TryGetRegistry<Charm>(out var registry)) {
                registry.Register("charm_god");
            }
        }
    }
}