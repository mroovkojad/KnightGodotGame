using Godot;
using System;

public partial class MenuButton : Button
{
    // Additional customization can be added here
    public override void _Ready()
    {
        // Example customization (optional)
        Modulate = Colors.White;
    }

    public void SetLabel(string text)
    {
        Text = text; // If using a Label node inside, adjust accordingly
    }
}