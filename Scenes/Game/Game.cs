using Godot;
using System;

public partial class Game : Node2D
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello Word");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GD.Print(delta);
	}
}
