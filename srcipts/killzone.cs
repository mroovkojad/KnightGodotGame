using Godot;
using System;

public partial class Killzone : Area2D
{
	private Timer timer;

	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		timer.Timeout += OnTimerTimeout;
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}
	public void OnBodyEntered(Node2D body)
	{
		Engine.TimeScale = 0.5f;
		body.GetNode("CollisionShape2D").QueueFree();
		timer.Start();
	}

	private void OnTimerTimeout()
	{
		Engine.TimeScale = 1.0f;
		GD.Print("Works");
		GetTree().ReloadCurrentScene();
	}

}
