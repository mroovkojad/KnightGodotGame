using Godot;
using System.Collections.Generic;

public partial class ThemeManager: Node
{
    private Dictionary<string, Theme> _themes = new Dictionary<string, Theme>();

    public override void _Ready()
    {
        CreateThemes();
    }

    private void CreateThemes()
    {
        _themes["MinorTextTheme"] = CreateMinorTextTheme();
    }

    private Theme CreateMinorTextTheme()
    {
        Theme theme = new Theme();
        string[] applicableControls = new string[] { "Button", "Label", "CheckBox" };
        foreach (string control in applicableControls)
        {
            theme.SetFontSize("font_size", control, 16);
        }

        return theme;
    }

    public Theme GetTheme(string themeName)
    {
        return _themes[themeName];
    }

}