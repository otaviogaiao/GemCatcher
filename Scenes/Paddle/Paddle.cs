using Godot;
using System;

public partial class Paddle : Area2D
{
	[Export] private float _speed = 100.0f;
	[Export] private float _margin = 50f;
	
	[Signal]
	public delegate void ScoredEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AreaEntered += OnAreaEntered;
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_onKeyPressed(delta);
	}


	private void _onKeyPressed(double delta)
	{
		if (Input.IsActionPressed("right"))
		{
			Position += new Vector2(_speed * (float)delta, 0);
		} 
		if (Input.IsActionPressed("left"))
		{
			Position -= new Vector2(_speed * (float)delta, 0);
		}

		Rect2 vpr = GetViewportRect();

		if (Position.X < vpr.Position.X + _margin)
		{
			Position = new Vector2(vpr.Position.X + _margin, Position.Y);
		} else if (Position.X > vpr.End.X - _margin)
		{
			Position = new Vector2(vpr.End.X - _margin, Position.Y);
		}
	}
	
	private void OnAreaEntered(Area2D area)
	{
		GD.Print("Scored!");
		EmitSignal(SignalName.Scored);
		area.QueueFree();
	}
}
