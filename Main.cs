using Godot;
using System;

public partial class Main : Node2D
{
	Player humanplayer;
	DrawPile drawPile;
	public void GameStart() 
	{
		ResetAll();
	}
	private void ResetAll() 
	{
		for(int i = 0; i < 4; i++) 
		{
			string playerName = "Player" + i.ToString();
			GetNode<Player>(playerName).Reset();
		}
		drawPile.Reset();
	}
	public override void _Ready()
	{
		humanplayer = GetNode<Player>("Player1");
		drawPile = GetNode<DrawPile>("DrawPile");
		GameStart();
	}
}
