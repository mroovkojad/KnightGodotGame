using Godot;
using System;
using System.Collections.Generic;

[Tool]
public partial class Bottle : Node2D
{
	private AnimatedSprite2D _animatedSprite;

	public enum BottleColor
	{
		Green,
		Orange,
		Pink,
		Blue
	}

	[Export]
	public BottleColor Color
	{
		get => _color;
		set
		{
			_color = value;
			if (_animatedSprite != null)
			{
				UpdateSpriteColor();
			}
		}
	}
	private BottleColor _color = BottleColor.Green;

	// Mapping enum values to frame numbers
	private readonly Dictionary<BottleColor, int> _colorFrameMap = new Dictionary<BottleColor, int>
	{
		{ BottleColor.Green, 0 },
		{ BottleColor.Orange, 1 },
		{ BottleColor.Pink, 2 },
		{ BottleColor.Blue, 3 }
	};

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("BottleSprite");
		UpdateSpriteColor();
	}

	private void UpdateSpriteColor()
	{
		if (_colorFrameMap.TryGetValue(Color, out int frame))
		{
			_animatedSprite.Frame = frame;
		}
		else
		{
			GD.PrintErr($"No frame mapped for color: {Color}");
		}
	}
}