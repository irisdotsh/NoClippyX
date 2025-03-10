using System;
using Dalamud.Game.Text;
using ImGuiNET;

namespace NoClippyX
{
    public partial class Configuration
    {
        public bool LogToChat = false;
        public XivChatType LogChatType = XivChatType.None;
    }
}

// This is a module because why not
namespace NoClippyX.Modules
{
    public class Logging : Module
    {
        public override int DrawOrder => 8;

        public override void DrawConfig()
        {
            if (ImGui.Checkbox("Output to Chat Log", ref NoClippyX.Config.LogToChat))
                NoClippyX.Config.Save();
            PluginUI.SetItemTooltip("Sends logging to the chat log instead.");

            if (!NoClippyX.Config.LogToChat) return;

            if (ImGui.BeginCombo("Log Chat Type", NoClippyX.Config.LogChatType.ToString()))
            {
                foreach (var chatType in Enum.GetValues<XivChatType>())
                {
                    if (!ImGui.Selectable(chatType.ToString())) continue;

                    NoClippyX.Config.LogChatType = chatType;
                    NoClippyX.Config.Save();
                }

                ImGui.EndCombo();
            }

            PluginUI.SetItemTooltip("Overrides the default Dalamud chat channel.");
        }
    }
}
