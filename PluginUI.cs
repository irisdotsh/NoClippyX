﻿using ImGuiNET;
using NoClippyX;

namespace NoClippyX
{
    public static class PluginUI
    {
        public static void SetItemTooltip(string s, ImGuiHoveredFlags flags = ImGuiHoveredFlags.None)
        {
            if (ImGui.IsItemHovered(flags))
                ImGui.SetTooltip(s);
        }

        public static void Draw() => ConfigUI.Draw();
    }
}
