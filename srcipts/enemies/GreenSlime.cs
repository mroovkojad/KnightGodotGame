using Godot;
using System;

public partial class GreenSlime : CharacterBody2D
{
	private const float Speed = 30.0f;
	private const float JumpVelocity = -100.0f;
	private Vector2 direction;
	RayCast2D rayCastLeft;
	RayCast2D rayCastRight;
	RayCast2D rayCastDownLeft;
	RayCast2D rayCastDownRight;

	AnimatedSprite2D animatedSprite;

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		direction = new Vector2(1, 0);
		rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		rayCastRight = GetNode<RayCast2D>("RayCastRight");
		rayCastDownLeft = GetNode<RayCast2D>("RayCastDownLeft");
		rayCastDownRight = GetNode<RayCast2D>("RayCastDownRight");
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
		animatedSprite.Play("idle");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		if (rayCastRight.IsColliding() || !rayCastDownRight.IsColliding())
		{
			this.direction = new Vector2(-1, 0);
			animatedSprite.FlipH = true;
		}
		else if (rayCastLeft.IsColliding() || !rayCastDownLeft.IsColliding())
		{
			this.direction = new Vector2(1, 0);
			animatedSprite.FlipH = false;
		}


		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}


		if (this.direction != Vector2.Zero)
		{
			velocity.X = this.direction.X * Speed;
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
