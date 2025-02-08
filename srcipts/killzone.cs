using Godot;
using System;

public partial class killzone : Area2D
{
	private Timer timer;

	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		timer.Timeout += OnTimerTimeout;
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		GD.Print("Killzone ready");
	}
	public void OnBodyEntered(Node2D body)
	{
		GD.Print("You died!");
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
