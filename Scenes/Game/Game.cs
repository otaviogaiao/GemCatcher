using Godot;
using System;

public partial class Game : Node2D
{
	private const double GemMargin = 50.0;
	
	private static readonly AudioStream ExplodeSound = GD.Load<AudioStream>("res://assets/explode.wav");
	
	[Export] private PackedScene _gemScene;
	[Export] private Timer _timer;
	[Export] private Paddle _paddle;
	[Export] private Label _scoreLabel;
	[Export] private AudioStreamPlayer _musicPlayer;
	[Export] private AudioStreamPlayer2D _scoreSound;

	private int _score = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer.Timeout += SpawnGem;
		_paddle.Scored += OnScore;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void SpawnGem()
	{
		Gem gem = (Gem) _gemScene.Instantiate();
		AddChild(gem);

		var viewport = GetViewportRect();
		var xPosition = (float) GD.RandRange(viewport.Position.X + GemMargin, viewport.End.X - GemMargin);
		
		gem.Position = new Vector2(xPosition, -100);
		gem.GemOffScreen += OnGameOver;
	}

	private void OnScore()
	{
		GD.Print("Score increased!");
		_score += 1;
		_scoreLabel.Text = _score.ToString().PadLeft(4, '0');
		_scoreSound.Play();
	}

	private void OnGameOver()
	{
		GD.Print("Game over!");
		foreach (Node child in GetChildren())
		{
			child.SetProcess(false);
		}
		_timer.Stop();
		_musicPlayer.Stop();
		_musicPlayer.Stream = ExplodeSound;
		_musicPlayer.Play();
	}
}
