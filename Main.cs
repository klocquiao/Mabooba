using Godot;
using System;

public partial class Main : Node2D
{
	private void OnBeamHit() {
		GetNode<Hud>("HUD").ShowMessage("Game Over");
	}
	
	private void OnCircleQuotaFinish() {
		GetNode<Hud>("HUD").ShowMessage("Success!");
	}
	
	private void OnBeamDelayTimeout() {
		Random random = new Random();
		
		var beams = GetNode<Node2D>("Beams").GetChildren();
		
		int index = random.Next(beams.Count);
		((Beam)beams[index]).TelegraphBeam();
	}
}
