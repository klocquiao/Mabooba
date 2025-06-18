using Godot;
using System;

public partial class Circle : Area2D
{
	[Signal]
	public delegate void QuotaEventHandler();
	
	private void OnBodyEntered(Node2D body) {
		GetNode<Timer>("CircleTimer").Paused = false;
	}
	
	private void OnBodyExited(Node2D body) {
		GetNode<Timer>("CircleTimer").Paused = true;
	}
	
	private void OnCircleTimeout() {
		EmitSignal(SignalName.Quota);
	}
	
	public override void _Ready()
	{
		GetNode<Timer>("CircleTimer").Start();
	}

	public override void _Process(double delta)
	{
	}
}
