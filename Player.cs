using Godot;
using System;

public partial class Player : Node2D
{
	[Signal]
	public delegate void DieEventHandler(int playerNum);
	[Export]
	public int PlayerNum;

	private bool isDie = false;
	public bool IsStay() 
	{
		return GetNode<Stay>("Stay").IsStay();
	}
	public int Hearts() 
	{
		return GetNode<StatusCard>("StatusCard").GetHearts();
	}
	public int[] GetCardsNum()
	{
		return GetNode<Deck>("Deck").GetCardsNum();
	}
	public bool HasFriendShip(FriendShipBar.FriendShip theFriendShip)
	{
		return GetNode<FriendShipBar>("FriendShipBar").HasFriendShip(theFriendShip);
	}

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
}
