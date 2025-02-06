using Godot;
using System;

public partial class Coin : Area2D
{
	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}
	public void OnBodyEntered(Node2D body){
		GD.Print("+1 coin");
		QueueFree();
	}
}
