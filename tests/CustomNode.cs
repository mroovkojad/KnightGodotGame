using Godot;
using System;

public partial class CustomNode :Node
{

	[Export] private Vector2 position = new Vector2(0, 0);
	[Export] private Vector2 Velocity {get; set;} = new Vector2(1, 1);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
