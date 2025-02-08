using Godot;
using System;

public partial class PurpleSlime : Node2D
{

	const int SPEED = 60;
	int direction = 1;
	RayCast2D rayCastLeft;
	RayCast2D rayCastRight;
	AnimatedSprite2D animatedSprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		rayCastRight = GetNode<RayCast2D>("RayCastRight");
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (rayCastRight.IsColliding())
		{
			direction = -1;
			animatedSprite.FlipH = true;
		}
		if (rayCastLeft.IsColliding())
		{
			direction = 1;
			animatedSprite.FlipH = false;
		}

        float  XMoveModifier = direction * SPEED * (float)delta;
		this.Position += new Vector2(XMoveModifier, 0);
	}
}
