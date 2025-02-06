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
	}
	public void OnBodyEntered(Node2D body)
	{
		GD.Print("You died!");
		timer.Start();
	}

	private void OnTimerTimeout()
	{
		GD.Print("Works");
		GetTree().ReloadCurrentScene();
	}

}
