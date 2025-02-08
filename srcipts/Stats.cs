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
		coinCountLabel = GetNode<Label>("%CoinCountLabel");
		coinCountLabel.Text = ": "+ coinCount;
	}

	public void AddPoint()
	{
		coinCount += 1;
		coinCountLabel.Text = ": " + coinCount;	// Add a point to the player's stats.
	}
}
