using BepInEx;
using BepInEx.Logging;

namespace ModManager
{
    [BepInPlugin(GUID, NAME, VERSION), BepInDependency("Crafterbot.MonkeStatistics")]
    internal class Main : BaseUnityPlugin
    {
        internal const string
            GUID = "crafterbot.gtag.modmanager",
            NAME = "Mod Toggle",
            VERSION = "1.0.0";
        internal static ManualLogSource manualLogSource;
        private void Awake() =>
            MonkeStatistics.API.Registry.AddAssembly();
    }

    internal static class Extensions
    {
        internal static void Log(this object obj, LogLevel logLevel = LogLevel.Info)
        {
#if DEBUG
            Main.manualLogSource.Log(logLevel, obj);
#endif
        }
    }
}
