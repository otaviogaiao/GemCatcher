using Godot;
using System;

public partial class Paddle : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("right"))
		{
			Position += new Vector2(100.0f * (float)delta, 0);
		} 
		if (Input.IsActionPressed("left"))
		{
			Position -= new Vector2(100.0f * (float)delta, 0);
		}
	}
}
