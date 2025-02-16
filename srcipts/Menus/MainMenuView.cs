using Godot;
using System;
using System.Collections.Generic;
public partial class MainMenuView : Control
{
    [Signal] public delegate void OptionSelectedEventHandler(int index);

    private Button[] _buttons;

    public override void _Ready()
    {
        var children = GetChildren();
        var buttonList = new List<Button>();

        foreach (var child in children)
        {
            if (child is Button button)
                buttonList.Add(button);
        }

        _buttons = buttonList.ToArray();

        for (int i = 0; i < _buttons.Length; i++)
        {
            int index = i; // Capture index for closure
            _buttons[i].Pressed += () => EmitSignal(nameof(OptionSelectedEventHandler), index);
        }
    }
}
