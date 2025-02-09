using Godot;
using System;

public partial class Coin : Area2D
{
	Stats stats;
	public override void _Ready()
	{
		stats = GetNode<Stats>("%Stats");
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}
	public void OnBodyEntered(Node2D body){
		stats.AddCoin();
		QueueFree();
	}
}
