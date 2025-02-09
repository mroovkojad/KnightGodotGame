using Godot;
using System;
using System.Reflection.Metadata.Ecma335;

public partial class Player : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;
	AnimatedSprite2D animatedSprite;
	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public void flipSprite(Vector2 velocity, AnimatedSprite2D animatedSprite)
	{
		switch (velocity.X)
		{
			case float x when x > 0:
				animatedSprite.FlipH = false;
				break;
			case float x when x < 0:
				animatedSprite.FlipH = true;
				break;
			default:
				break;
		}
	}

	public void playAnimation(Vector2 velocity, AnimatedSprite2D animatedSprite)
	{
		if (IsOnFloor())
		{
			switch (velocity.X)
			{
				case float x when x > 0:
					animatedSprite.Play("run");
					break;
				default:
					animatedSprite.Play("idle");
					break;
			}
		}
		else
		{
			animatedSprite.Play("jump");
		}
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("escape_to_menu"))
		{
			GD.Print("Escape button pressed");
			SceneManager.instance.ChangeScene(MainScenes.MainMenu);
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("move_left", "move_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		playAnimation(velocity, animatedSprite);
		flipSprite(velocity, animatedSprite);

		Velocity = velocity;
		MoveAndSlide();
	}
}
