using Godot;
using System;

public partial class TurnIndicator : Node2D
{
	private int whosTurn = 0;
	
	public int GetTurn() 
	{
		return whosTurn;
	}
	public void ChangeTurn() 
	{
		GetNode<ColorRect>("Turn" + whosTurn.ToString()).Hide();
		whosTurn = (whosTurn + 1) % 4;
		GetNode<ColorRect>("Turn" + whosTurn.ToString()).Show();
	}

	public void Reset() 
	{
		GetNode<ColorRect>("Turn" + whosTurn.ToString()).Hide();
		whosTurn = 0;
		GetNode<ColorRect>("Turn0").Show();
	}
}
