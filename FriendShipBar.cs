using Godot;
using System;

public partial class FriendShipBar : Node2D
{
	[Flags]
	public enum FriendShip 
	{
		Red = 1,
		Yellow = 2,
		Blue = 4,
		Green = 8,
		White = 16,
		Orange = 32,
	}

	private FriendShip friendShip = 0;
	public bool HasFriendShip(FriendShip theFriendShip) 
	{
		return (friendShip & theFriendShip) != 0;
	}
	public void AddFriendShip(FriendShip theFriendShip)
	{
		friendShip |= theFriendShip;
		GetNode<ColorRect>(theFriendShip.ToString()).Show();
	}
	public void RemoveFriendShip(FriendShip theFriendShip) 
	{
		friendShip &= ~theFriendShip;
		GetNode<ColorRect>(theFriendShip.ToString()).Hide();
	}

	public void Reset() 
	{
		for(int i = 1;i <= (int)FriendShip.Orange; i <<= 1) 
		{
			RemoveFriendShip((FriendShip)i);
		}
	}
}
