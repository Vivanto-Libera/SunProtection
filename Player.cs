using Godot;
using System;

public partial class Player : Node2D
{
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
}
