using Godot;
using System;

public partial class Hud : CanvasLayer
{
	public void ShowMessage(string text) {
		var message = GetNode<Label>("Message");
		message.Text = text;
		message.Show();
	}
}
