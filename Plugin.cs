using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace Infite_PlatfromAbility_Size
{
    [BepInPlugin("com.000diggity000.Infite_PlatfromAbility_Size", "Infinite Platformability Size", "1.0.0")]//A unique name could be anything, The name of your plugin, The version of your plugin
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_NAME} is loaded!");//feel free to remove this
            Harmony harmony = new Harmony("com.000diggity000.Infite_PlatfromAbility_Size");
            MethodInfo original = AccessTools.Method(typeof(PlatformTransform), "Awake");
            MethodInfo patch = AccessTools.Method(typeof(Patches), "Awake_Platform_Plug");
            harmony.Patch(original, new HarmonyMethod(patch));
        }
        public class Patches
        {
            public static bool Awake_Platform_Plug(PlatformTransform __instance)
            {

                __instance.maxArea = (Fix)99999999f;
                __instance.maxSizeTime = (Fix)99999999f;
                __instance.MaxSize = (Fix)99999999f;

                return true;
            }
        }

    }
}
