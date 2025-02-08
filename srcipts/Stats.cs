using Godot;
using System;

public partial class Stats : CanvasLayer
{
	int coinCount;
	Label coinCountLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		coinCount = 0;
		coinCountLabel = GetNode<Label>("%coinCountLabel");
		coinCountLabel.Text = "Coin count: " + coinCount;
	}

	public void AddPoint()
	{
		coinCount += 1;
		coinCountLabel.Text = "Coin count: " + coinCount;	// Add a point to the player's stats.
	}
}
