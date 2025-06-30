using Godot;
using System;
using System.Collections.Generic;

public partial class BeamManager : Node2D
{	
	private Beam[] beams = [];
	
	[Signal]
	public delegate void HitEventHandler();
	
	public override void _Ready() {
		beams = [
			GetNode<Beam>("Beam"),
			GetNode<Beam>("Beam2"),
			GetNode<Beam>("Beam3"),
			GetNode<Beam>("Beam4"),
			GetNode<Beam>("Beam5"),
			GetNode<Beam>("Beam6"),
		];
	}
	
	public void Stop() {
		GetNode<Timer>("BeamDelayTimer").Stop();
	}
	
	private void OnBeamHit() {
		EmitSignal(SignalName.Hit);
	}
	
	private void OnBeamDelayTimeout() {
		Random random = new Random();
		
		List<Beam> active = new List<Beam>();
		foreach (var beam in beams) {
			if (beam.bodies.Count > 0) {
				active.Add(beam);
			}
		}
	
		
		int index = random.Next(active.Count);
		(active[index]).TelegraphBeam();
	}
}
