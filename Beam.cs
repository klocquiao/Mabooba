using Godot;
using System;
using System.Collections.Generic;

public partial class Beam : Area2D
{
	[Signal]
	public delegate void HitEventHandler();
	
	[Export]
	public float BeamTimer = 0.5f;
	
	[Export]
	public bool isVertical = false;
	
	public bool isFiring = false;
	
	public List<Node2D> bodies = new List<Node2D>();
	
	private void OnBodyEntered(Node2D body)
	{
		// Check if is firing
		bodies.Add(body);
	}
	
	private void OnBodyExited(Node2D body) {
		bodies.Remove(body);
	}
	
	private void FireBeam() {
		if (bodies.Count != 0) {
			EmitSignal(SignalName.Hit);
		}
		
		Visible = false;
	}

	public void TelegraphBeam()
	{
		// Show telegraph for 1.5 seconds
		// 
		Visible = true;
		var tween = GetTree().CreateTween();
		tween.TweenProperty(GetNode<Sprite2D>("Sprite2D"), "modulate", new Color(1, 0, 0, 0.3f), BeamTimer);
		tween.TweenProperty(GetNode<Sprite2D>("Sprite2D"), "modulate", new Color(0, 1, 1, 0.3f), BeamTimer);
		tween.TweenProperty(GetNode<Sprite2D>("Sprite2D"), "modulate", new Color(1, 0, 0, 0.3f), BeamTimer);
		tween.TweenProperty(GetNode<Sprite2D>("Sprite2D"), "modulate", new Color(1, 1, 1, 0.0f), BeamTimer);
		tween.TweenCallback(Callable.From(() => {
			FireBeam();
		}));
	}
	
	public override void _Ready()
	{
		Visible = false;
		if (Mathf.Floor(Mathf.RadToDeg(Rotation)) == 90) {
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Animation = "attack-down";
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Rotation = Mathf.DegToRad(-90);
		}
		//TelegraphBeam();
	}
}
