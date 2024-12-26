using Godot;
using System;

public partial class Gem : Area2D
{

	[Export] private float _speed = 100.0f;

	[Export] private float _rotationSpeed = 25f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += new Vector2(0f, _speed * (float)delta);
		var currentRotation = GetRotation();

		var newRotation = currentRotation + (_rotationSpeed);
		if (newRotation >= 360)
		{
			newRotation -= 360;
		}
		SetRotation(newRotation);
	}
}
