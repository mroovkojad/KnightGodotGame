using Godot;
using System;

public partial class TestPlayer : Node
{
    public new string Name { get; set; }
    public int Level { get; set; }
    public float Health { get; set; }
    public Vector2 Position { get; set; }

    public override void _Ready()
    {
        Name = "Player";
        Level = 1;
        Health = 100.0f;
        Position = new Vector2(0, 0);
    }
}