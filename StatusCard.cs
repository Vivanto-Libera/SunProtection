using Godot;
using System;

public partial class StatusCard : TextureRect
{
	[Signal]
	public delegate void DieEventHandler();

	private int hearts = 4;
	public int GetHearts() 
	{
		return hearts;
	}
	public void DecreaseHearts() 
	{
		if(hearts <= 0) 
		{
			return;
		}
		hearts--;
		if(hearts == 0) 
		{
			Texture = GD.Load<Texture2D>("res://Image/StateDie.jpg");
			EmitSignal(SignalName.Die);
		}
		string labelText = "x" + hearts.ToString();
		GetNode<Label>("label").Text = labelText;
	}

	public void Reset() 
	{
		Texture = GD.Load<Texture2D>("res://Image/StateLive.jpg");
		hearts = 4;
		GetNode<Label>("label").Text = "x4";
	}
}
