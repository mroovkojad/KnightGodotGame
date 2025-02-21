using Godot;
using System;

public partial class Coin : Area2D
{
	Stats stats;
	AnimationPlayer animationPlayer;
	public override void _Ready()
	{
		stats = GetNode<Stats>("%Stats");
		if (!IsConnected("body_entered", new Callable(this, nameof(OnBodyEntered))))
		{
			Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		}
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		GD.Print("Coin ready");
	}
	public void OnBodyEntered(Node2D body){
		stats.AddCoin();
		animationPlayer.Play("pickup");
	}
}
