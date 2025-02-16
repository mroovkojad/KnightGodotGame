using Godot;
using System;

[Tool]
[GlobalClass]
public partial class LevelBoundry : Node
{
	private static Vector2 defaultLevelSize = new Vector2(3000, 1000);
	private static Vector2 defaultOrigin = new Vector2(0, 0);
	[Export]
	private Vector2 levelSize;

	[Export]
	private Vector2 origin;

	[Export]
	private CollisionShape2D leftShape;

	[Export]
	private CollisionShape2D rightShape;

	[Export]
	private CollisionShape2D topShape;

	[Export]
	private CollisionShape2D bottomShape;
	public override void _Ready()
	{
		levelSize = defaultLevelSize;
	}
	private void AddCollisionShapeSides(Vector2 levelSize){
		this.leftShape = new CollisionShape2D();
		WorldBoundaryShape2D leftBoundry = new WorldBoundaryShape2D();
		leftBoundry.Distance = 0;
		leftBoundry.Normal = new Vector2(-1, 0);
		leftShape.Shape = leftBoundry;
		AddChild(leftShape);

		this.rightShape = new CollisionShape2D();
		WorldBoundaryShape2D rightBoundry = new WorldBoundaryShape2D();
		rightBoundry.Distance = levelSize.X;
		rightBoundry.Normal = new Vector2(1, 0);
		rightShape.Shape = rightBoundry;
		AddChild(rightShape);

		this.topShape = new CollisionShape2D();
		WorldBoundaryShape2D topBoundry = new WorldBoundaryShape2D();
		topBoundry.Distance = 0;
		topBoundry.Normal = new Vector2(0, -1);
		topShape.Shape = topBoundry;
		AddChild(topShape);

		this.bottomShape = new CollisionShape2D();
		WorldBoundaryShape2D bottomBoundry = new WorldBoundaryShape2D();
		bottomBoundry.Distance = levelSize.Y;
		bottomBoundry.Normal = new Vector2(0, 1);
		bottomShape.Shape = bottomBoundry;
		AddChild(bottomShape);
	}
}
