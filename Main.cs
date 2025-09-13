using Godot;
using System;
using static Card.Face;

public partial class Main : Node2D
{
	Player humanplayer;
	DrawPile drawPile;
	TurnIndicator turnIndicator;
	public void GameStart() 
	{
		ResetAll();
	}

	public void OnDrawedCard(int face) 
	{
		Acted(humanplayer, face);
	}
	public void Acted(Player player, int face) 
	{

	}

	private void ResetAll() 
	{
		for(int i = 0; i < 4; i++) 
		{
			string playerName = "Player" + i.ToString();
			GetNode<Player>(playerName).Reset();
		}
		drawPile.Reset();
		turnIndicator.Reset();
	}
	public override void _Ready()
	{
		humanplayer = GetNode<Player>("Player1");
		drawPile = GetNode<DrawPile>("DrawPile");
		turnIndicator = GetNode<TurnIndicator>("TurnIndicator");
		GameStart();
	}
}
