using Godot;
using System;

public partial class SelectPlayer : Node2D
{
	[Signal]
	public delegate void SelectedPlayerEventHandler(int playerNum);
	public void OnSelectedPlayer(int number) 
	{
		EmitSignal(SignalName.SelectedPlayer, number);
	}
	public void HideButtons() 
	{
        GetNode<SelectButton>("Player0").Hide();
        GetNode<SelectButton>("Player1").Hide();
		GetNode<SelectButton>("Player2").Hide();
		GetNode<SelectButton>("Player3").Hide();
	}
	public void ShowButtons() 
	{
        GetNode<SelectButton>("Player0").Show();
        GetNode<SelectButton>("Player1").Show();
		GetNode<SelectButton>("Player2").Show();
		GetNode<SelectButton>("Player3").Show();
	}
}
