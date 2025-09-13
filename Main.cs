using Godot;
using System;

public partial class Main : Node2D
{
	Player humanplayer;
	
	public void GameStart() 
	{

	}
	private void ResetAll() 
	{

	}
	public override void _Ready()
	{
		humanplayer = GetNode<Player>("Player1");
	}
}
