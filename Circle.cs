using Godot;
using System;

public partial class Circle : Area2D
{
	[Signal]
	public delegate void QuotaEventHandler();
	
	public void Stop() {
		GetNode<Timer>("CircleTimer").Stop();
	}
	
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
		GetNode<Timer>("CircleTimer").Paused = true;
	}

	public override void _Process(double delta)
	{
	}
}
