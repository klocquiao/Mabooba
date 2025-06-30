using Godot;
using System;

public partial class Main : Node2D
{
	private void GameOver() {
		GetNode<BeamManager>("BeamManager").Stop();
		GetNode<Circle>("Circle").Stop();
		GetNode<Hud>("HUD").ShowMessage("Game Over");
	}
	
	private void Win() {
		GetNode<Hud>("HUD").ShowMessage("Success!");
	}
	
	private void OnBeamHit() {
		GameOver();
	}
	
	private void OnCircleQuotaFinish() {
		Win();
	}

}
