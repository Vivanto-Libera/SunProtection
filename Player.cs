using Godot;
using System;

public partial class Player : Node2D
{
	[Signal]
	public delegate void DieEventHandler(int playerNum);
	[Export]
	public int PlayerNum;

	private bool isDie = false;
	public Deck deck;
	public FriendShipBar friendShipBar;
	public StatusCard statusCard;
	public Stay stay;

	public bool IsDie() 
	{
		return isDie;
	}
	public void PlayerDie() 
	{
		isDie = true;
		EmitSignal(SignalName.Die, PlayerNum);
	}

	public void Reset() 
	{
		GetNode<StatusCard>("StatusCard").Reset();
		GetNode<FriendShipBar>("FriendShipBar").Reset();
		GetNode<Stay>("Stay").Reset();
		GetNode<Deck>("Deck").Reset();
	}
    public override void _Ready()
    {
		deck = GetNode<Deck>("Deck");
		friendShipBar = GetNode<FriendShipBar>("FriendShipBar");
		statusCard = GetNode<StatusCard>("StatusCard");
		stay = GetNode<Stay>("Stay");
    }
}
