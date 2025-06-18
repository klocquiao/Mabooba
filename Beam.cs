using Godot;
using System;

public partial class Beam : Area2D
{
	[Signal]
	public delegate void HitEventHandler();
	
	[Export]
	public float BeamTimer = 1.0f;
	
	public bool isFiring = false;
	
	private void OnBodyEntered(Node2D body)
	{
		// Check if is firing

		if (isFiring)
		{
			// A character was hit by the beam
			EmitSignal(SignalName.Hit);
		}
	}
	
	private void OnFiringTimeout() {
		isFiring = false;
		
		var tween = GetTree().CreateTween();
		tween.TweenCallback(Callable.From(GetNode<Sprite2D>("Sprite2D").QueueFree));
	}

	public void FireBeam()
	{
		isFiring = false;
		var tween = GetTree().CreateTween();
		tween.TweenProperty(GetNode<Sprite2D>("Sprite2D"), "modulate", new Color(0, 1, 1, 0.8f), BeamTimer);
		tween.TweenCallback(Callable.From(() => {
			isFiring = true;
			GetNode<Timer>("FiringTimer").Start();
		}));
	}
	
	public override void _Ready()
	{
		FireBeam();
	}
}
