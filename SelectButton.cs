using Godot;
using System;

public partial class SelectButton : Button
{
	[Signal]
	public delegate void SelectButtonPressedEventHandler(int number);
	[Export]
	public int Number;

	public void OnPressed() 
	{
		EmitSignal(SignalName.SelectButtonPressed, Number);
	}
}
