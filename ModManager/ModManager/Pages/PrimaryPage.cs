using BepInEx.Bootstrap;
using HarmonyLib;
using MonkeStatistics.API;

namespace ModManager.Pages
{
    [DisplayInMainMenu(Main.NAME)]
    internal class PrimaryPage : Page
    {
        public override void OnPageOpen()
        {
            base.OnPageOpen();

            foreach (var plugin in Chainloader.PluginInfos)
                //if (plugin.Key != Main.GUID)
                    if (AccessTools.Method(plugin.Value.Instance.GetType(), "OnEnable") != null && AccessTools.Method(plugin.Value.Instance.GetType(), "OnDisable") != null) // got this idea from computer interface by ToniMacaroni
                        AddLine(plugin.Value.Metadata.Name, new ButtonInfo((object Sender, object[] Args) => { plugin.Value.Instance.enabled = (bool)Args[1]; }, 0, ButtonInfo.ButtonType.Toggle, plugin.Value.Instance.enabled));
                    else
                        AddLine(plugin.Value.Metadata.Name + "(UNSUPPORTED)");
            SetTitle(Main.NAME);
            SetAuthor("By Crafterbot");
            SetLines();
        }
    }
}
