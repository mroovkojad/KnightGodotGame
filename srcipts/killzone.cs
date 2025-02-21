using Godot;

public partial class killzone : Area2D
{
	private Timer timer;

	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		timer.Timeout += OnTimerTimeout;
		if (!IsConnected("body_entered", new Callable(this, nameof(OnBodyEntered))))
		{
			Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		}
		GD.Print("Killzone ready");
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
